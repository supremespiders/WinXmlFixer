using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentFTP;
using Renci.SshNet;
using WinXmlFixer.Models;

namespace WinXmlFixer.Service;

public class FtpService
{
    private FtpClient _ftpClient;
    private SftpClient _sftpClient;
    private readonly string _host;
    private readonly string _user;
    private readonly string _pass;
    private readonly int _port = 2222;
    private readonly bool _isSftp;


    public FtpService(string host, string user, string pass)
    {
        _user = user;
        _pass = pass;
        var split = host.Split(':');
        if (split.Length < 2)
            throw new KnownException($"Host : {host} need to be of this format => FTP/SFTP:HostName:PORT example => SFTP:decoftp.deco-fenetres-sur-mesure.com:2222");
        _isSftp = split[0].ToUpper().Equals("SFTP");
        _host = split[1];
        if (split.Length == 3)
            _port = int.Parse(split[2]);
    }

    public void Disconnect()
    {
        try
        {
            if (_isSftp)
                _sftpClient?.Disconnect();
            else
                _ftpClient?.Disconnect();
        }
        catch (Exception)
        {
            //
        }
    }

    public async Task Connect(CancellationToken ct=new())
    {
        if (!_isSftp)
        {
            _ftpClient = new FtpClient(_host) { Credentials = new NetworkCredential(_user, _pass) }; //decoftp.deco-fenetres-sur-mesure.com "rozis", "cxyCrW"
                                                                                                     // _ftpClient.EncryptionMode = FtpEncryptionMode.Implicit;
                                                                                                     //_ftpClient.DataConnectionType = FtpDataConnectionType.PASV;
            await _ftpClient.ConnectAsync(ct);
        }
        else
        {
            _sftpClient = new SftpClient(_host, _port, _user, _pass);
            await Task.Run(() => _sftpClient.Connect(), ct);
        }
    }

    public async Task UploadFile(string localPath, string remotePath, CancellationToken ct = new())
    {
        if (_isSftp)
        {
            await using var ms = new MemoryStream(await File.ReadAllBytesAsync(localPath, ct));
            await Task.Run(()=>_sftpClient.UploadFile(ms, remotePath), ct);
        }
        else
        {
            await _ftpClient.UploadAsync(await File.ReadAllBytesAsync(localPath, ct), remotePath, token: ct);
        }
    }

    public async Task<List<string>> GetFilesList(string remoteDir, string nameContains = null, CancellationToken ct = new())
    {
        if (_isSftp)
        {
            var list = await Task.Run(() => _sftpClient.ListDirectory(remoteDir).Where(x => !x.IsDirectory), ct);
            if (nameContains != null)
                list = list.Where(x => x.Name.Contains(nameContains));
            var fileListings = list.Select(x => x.FullName).ToList();
            return fileListings;
        }
        else
        {
            var fileListings = (await _ftpClient.GetListingAsync(remoteDir, ct)).Where(x => x.Type == FtpFileSystemObjectType.File).Select(x => x.FullName).ToList();
            return fileListings;
        }
    }

    public async Task MoveFile(string fromPath, string toDir)
    {
        var fileName = Path.GetFileName(fromPath);
        if (_isSftp)
        {
            await Task.Run(() => _sftpClient.Get(fromPath).MoveTo(toDir + "/" + fileName));
        }
        else
        {
            var b = await _ftpClient.MoveFileAsync(fromPath, toDir + "/" + fileName);
        }
    }

    public async Task DownloadFile(string remotePath, string localDir, CancellationToken ct = new())
    {
        if (_isSftp)
            await DownloadFileSftp(remotePath, localDir, ct);
        else
            await DownloadFileFtp(remotePath, localDir, ct);
    }

    private async Task DownloadFileFtp(string remotePath, string localDir, CancellationToken ct = new())
    {
        var fileName = Path.GetFileName(remotePath);
        await _ftpClient.DownloadFileAsync(localDir + "/" + fileName, remotePath, token: ct);
    }

    private async Task DownloadFileSftp(string remotePath, string localDir, CancellationToken ct = new())
    {
        var fileName = Path.GetFileName(remotePath);
        await using var fs = new FileStream(localDir + "/" + fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
        await Task.Run(() => _sftpClient.DownloadFile(remotePath, fs), ct);
    }
}