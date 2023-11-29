using Crud.App.Core.DbContexti;
using Crud.App.Core.Interfaces;
using Crud.App.Core.Models;
using Crud.App.DataSource.Enums;
using Crud.App.DataSource.ResponceAndRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Infrastructure.Repositories
{
    public class AlbumAndPhotoServiceRepos:IAlbumAndPhotoRepos
    {
        private readonly DbRaisa dbRaisa;
        private readonly IErrorRepos errorRepos;
        private readonly ILogRepos logRepos;
        public AlbumAndPhotoServiceRepos(DbRaisa dbRaisa, IErrorRepos errorRepos, ILogRepos logRepos)
        {
            this.dbRaisa = dbRaisa;
            this.errorRepos = errorRepos;
            this.logRepos = logRepos;
        }
        #region getAllAlbum
        public List<Album> getAllAlbum()
        {
            return dbRaisa.Albums.ToList();
        }
        #endregion

        #region getPhotosByAlbumId
        public List<Photo> getPhotosByAlbumId(PhotoByAlbumId albumid)
        {
            try
            {
                var photo=dbRaisa.Photos.Where(i=>i.AlbumID==albumid.ID).ToList();
                if (photo == null)
                {
                     errorRepos.Action("No Photo for this album", ErrorEnums.Info);
                }
                return photo;
            }
            catch (Exception ex)
            {
                errorRepos.Action(ex.Message, ErrorEnums.Fatal);
                throw;
            }
        }
        #endregion

        #region getAlbumByUserId
        public List<Album> getAlbumByUserId(AlbumByUserId userid)
        {
            try
            {
                var album = dbRaisa.Albums.Where(i => i.UserID == userid.usserId).ToList();
                if (album == null)
                {
                    errorRepos.Action("No album for this User", ErrorEnums.Info);
                }
                return album;
            }
            catch (Exception ex)
            {
                errorRepos.Action(ex.Message, ErrorEnums.Fatal);
                throw;
            }
        }
        #endregion

    }
}
