using Crud.App.Core.Interfaces;
using Crud.App.Core.Models;
using Crud.App.DataSource.ResponceAndRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Services
{
    public class AlbumAndPhotoServices:IAlbumAndPhoto
    {
        private readonly IAlbumAndPhotoRepos albumPhotoRepos;
        public AlbumAndPhotoServices(IAlbumAndPhotoRepos albumPhotoRepos)
        {
            this.albumPhotoRepos = albumPhotoRepos;
        }

        public List<Album> getAlbumByUserId(AlbumByUserId userid)
        {
           return albumPhotoRepos.getAlbumByUserId(userid);
        }

        public List<Album> getAllAlbum()
        {
            return albumPhotoRepos.getAllAlbum();
        }

        public List<Photo> getPhotosByAlbumId(PhotoByAlbumId albumid)
        {
            return albumPhotoRepos.getPhotosByAlbumId(albumid);
        }
    }
}
