using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;
using VML.Encoding.Model.Interfaces;

namespace VML.Encoding.Model
{
    public class BasicCredentials : IEncodingCredentials
    {
        #region Constructors and Destructors

        public BasicCredentials(string userId, string userKey)
        {
            UserId = userId;
            UserKey = userKey;
        }

        #endregion

        #region Public Properties

        [Required]
        public string UserId { get; private set; }

        [Required]
        public string UserKey { get; private set; }

        #endregion
    }
}