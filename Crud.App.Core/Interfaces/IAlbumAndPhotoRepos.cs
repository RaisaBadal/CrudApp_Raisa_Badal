using Crud.App.Core.Models;
using Crud.App.DataSource.ResponceAndRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Interfaces
{
    public interface IAlbumAndPhotoRepos
    {
        List<Album> getAllAlbum();
        List<Photo> getPhotosByAlbumId(PhotoByAlbumId albumid);
        List<Album> getAlbumByUserId(AlbumByUserId userid);
    }
}
