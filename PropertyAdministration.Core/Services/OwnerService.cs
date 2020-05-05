using PropertyAdministration.Application.AppModels;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyAdministration.Core.Services
{
   public  class OwnerService: IOwnerService
    {
        private IHouseRepository _houseRepository;
        private IOwnerRepository _ownerRepository; 

        public OwnerService(IOwnerRepository ownerRepository, IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
            _ownerRepository = ownerRepository;

        }
        public IEnumerable<OwnerIndexViewModel> GetAll()
        {
            var owners = _ownerRepository.GetAll.ToList() 
                .Select(a => new OwnerIndexViewModel
                { 
                    Title = a.Title,
                    FullName = a.FullName,
                    OwnerId = a.OwnerId,
                    PhoneNumber = a.PhoneNumber,
                    PropertiesOwned = a.PropertiesOwned, 
                     EmailAddress = a.EmailAddress, 
                     HouseAddress = a.Houses.Count > 0 ? a.Houses.FirstOrDefault().StreetName : "" //+ " "  + a.Houses.FirstOrDefault().StreetName
                });; 
               
            return owners;
        }
        public OwnerViewModel GetById(int id)
        {
            Owner owner = _ownerRepository.GetById(id);

            return  new OwnerViewModel
            {
                OwnerId = owner.OwnerId,
                FullName = owner.FullName,
                Title = owner.Title,
                EmailAddress = owner.EmailAddress,
                EmailAddress2 = owner.EmailAddress2,
                PhoneNumber = owner.PhoneNumber,
                PhoneNumber2= owner.PhoneNumber2,
                PhoneNumber3 = owner.PhoneNumber3 ,
                PropertiesOwned = owner.PropertiesOwned   
                 
            };  
        }
        public void Edit(OwnerEditViewModel ownerVM)
        {
            Owner owner = new Owner()
            {
                OwnerId = ownerVM.Owner.OwnerId,
                EmailAddress = ownerVM.Owner.EmailAddress,
                EmailAddress2 = ownerVM.Owner.EmailAddress2,
                FullName = ownerVM.Owner.FullName,
                Title = ownerVM.Owner.Title,
                PhoneNumber = ownerVM.Owner.PhoneNumber,
                PhoneNumber2 = ownerVM.Owner.PhoneNumber2,
                 PhoneNumber3 = ownerVM.Owner.PhoneNumber3,
                 PropertiesOwned = ownerVM.Owner.PropertiesOwned
            };

            _ownerRepository.Edit(owner);

            _ownerRepository.Save();  

        }
        public void Create(OwnerEditViewModel ownerVM)
        {
            Owner owner = new Owner()
            {
                //OwnerId = ownerVM.Owner.OwnerId,
                EmailAddress = ownerVM.Owner.EmailAddress,
                EmailAddress2 = ownerVM.Owner.EmailAddress2,
                FullName = ownerVM.Owner.FullName,
                Title = ownerVM.Owner.Title,
                PhoneNumber = ownerVM.Owner.PhoneNumber,
                PhoneNumber2 = ownerVM.Owner.PhoneNumber2,
                PhoneNumber3 = ownerVM.Owner.PhoneNumber3,
                PropertiesOwned = ownerVM.Owner.PropertiesOwned
            };

            _ownerRepository.Edit(owner);

            _ownerRepository.Save();

        }
        public void Delete(int id)
        {
            _ownerRepository.Delete(id);
        }
         

        public void Save()
        {
            _ownerRepository.Save();

        }
    }
}
