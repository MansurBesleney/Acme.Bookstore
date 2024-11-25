using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Emailing;
using Volo.Abp.OpenIddict.Authorizations;

namespace Acme.Bookstore.Authors
{
    public class Author : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; set; }
        public string ShortBio {  get; set; }

        private Author() { }

        internal Author(
            Guid id,
            string name,
            DateTime birthDate,
            string shortBio)
            : base(id)
        {
            SetName(name);
            BirthDate = birthDate;
            ShortBio = shortBio;
        }

        internal Author ChangeName(string name)
        {
            SetName(name);
            return this;
        }

        private void SetName(string Name)
        {
            Name = Check.NotNullOrWhiteSpace(
                Name,
                nameof(Name),
                maxLength : AuthorConsts.MaxNameLength);
        }
    }
}
