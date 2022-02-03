using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Philcosa.Application.Interfaces.Chat;
using Philcosa.Application.Models.Chat;
using Philcosa.Domain.Contracts;

namespace Philcosa.Infrastructure.Models.Identity
{
    public class PhilcosaUser : IdentityUser<string>, IChatUser, IAuditableEntity<string>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string CreatedBy { get; set; }

        [Column(TypeName = "text")]
        public string ProfilePictureDataUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        public bool IsActive { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public virtual ICollection<ChatHistory<PhilcosaUser>> ChatHistoryFromUsers { get; set; }
        public virtual ICollection<ChatHistory<PhilcosaUser>> ChatHistoryToUsers { get; set; }

        public PhilcosaUser()
        {
            ChatHistoryFromUsers = new HashSet<ChatHistory<PhilcosaUser>>();
            ChatHistoryToUsers = new HashSet<ChatHistory<PhilcosaUser>>();
        }
    }
}