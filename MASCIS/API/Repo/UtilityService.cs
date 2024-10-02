using MASCIS.API.Context;
using MASCIS.API.Interface;
using MASCIS.SHARED.Context;
using MASCIS.SHARED.DTO;
using MASCIS.SHARED.Models.PVModels;
using MASCIS.SHARED.Models.Utility;
using Microsoft.EntityFrameworkCore;

namespace MASCIS.API.Repository
{
    public class UtilityService : IUtilityService
    {
        private readonly UtilityContext db;
        private readonly PVContext pvcontextdb;
        public UtilityService(UtilityContext db, PVContext pvcontextdb)
        {
            this.db = db;
            this.pvcontextdb = pvcontextdb;
        }

        public List<ADrugRegimen> GetDrugRegimens()
        {
            return db.ADrugRegimen.AsNoTracking().ToList();
        }
        public List<ATreatmentCategory>? GetATreatmentCategory()
        {
            return db.ATreatmentCategory.AsNoTracking().ToList();
        }
        public async Task<List<ADrugRegimenCategory>?> GetADrugRegimenCategory()
        {
            return await db.ADrugRegimenCategory.AsNoTracking().ToListAsync();
        }

        public async Task<List<ADrugRegimenClassification>?> GetADrugRegimenClassification()
        {
            return await db.ADrugRegimenClassification.AsNoTracking().ToListAsync();
        }

        public async Task<List<APhysicalCountStatus>?> GetAPhysicalCountStatus()
        {
            return await db.APhysicalCountStatus.AsNoTracking().ToListAsync();
        }
        public List<AFacilities>? GetFacilities()
        {
            return db.AFacilities.AsNoTracking().ToList();
        }
        public async Task <List<ACycle>?> GetLocalCycle()
        {
            return db.ACycle.AsNoTracking().ToList();
        }
        public List<AOrderStatus>? GetOrderStatus()
        {
            return db.AOrderStatus.AsNoTracking().ToList();
        }

        public List<AOrderType>? GetOrderType()
        {
            return db.AOrderType.AsNoTracking().ToList();
        }

       

        public List<AProductCategory>? GetProductCategory()
        {
            return db.AProductCategory.AsNoTracking().ToList();
        }

        public List<AProductClassification>? GetProductClassification()
        {
            return db.AProductClassification.AsNoTracking().ToList();
        }

        public async Task<List<AContacts>?> GetContacts()
        {
            return await db.AContacts.AsNoTracking().ToListAsync();
        }

        public async Task<List<AContactCategory>?> GetContactCategory()
        {
            return await db.AContactCategory.AsNoTracking().ToListAsync();
        }

        public async Task<List<AFacilityType>?> GetFacilityType()
        {
            return await db.AFacilityType.AsNoTracking().ToListAsync();
        }

        public async Task<List<ADeliveryZone>?> GetDeliveryZone()
        {
            return await db.ADeliveryZone.AsNoTracking().ToListAsync();
        }

        public async Task<List<AImplimentingPartners>?> GetImplementingPartner()
        {
            return await db.AImplimentingPartners.AsNoTracking().ToListAsync();
        }

        public async Task<List<ADistrict>?> GetDistrict()
        {
            return await db.ADistrict.AsNoTracking().ToListAsync();
        }

        public async Task<List<AFacilityLevelOfCare>?> GetLevelOfCare()
        {
            return await db.AFacilityLevelOfCare.AsNoTracking().ToListAsync();
        }

        public async Task<List<AOwnership>?> GetOwnership()
        {
            return await db.AOwnership.AsNoTracking().ToListAsync();
        }

        public async Task<List<ACdcregion>?> GetCdcRegion()
        {
            return await db.ACdcregion.AsNoTracking().ToListAsync();
        }

        public async Task SaveFacility(AFacilities data)
        {
            var exists = db.AFacilities.FirstOrDefault(o => o.FacilityCode == data.FacilityCode);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.AFacilities.OrderBy(o => o.FacilityCode).LastOrDefault();
                if (last != null)
                {
                    id = (last.FacilityCode + 1);
                }
                data.FacilityCode = id;
                db.AFacilities.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveContact(AContacts data)
        {
            var exists = db.AContacts.FirstOrDefault(o => o.ContactId == data.ContactId);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.AContacts.OrderBy(o => o.ContactId).LastOrDefault();
                if (last != null)
                {
                    id = (last.ContactId + 1);
                }
                data.ContactId = id;
                db.AContacts.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveProduct(AProduct data)
        {
            var exists = db.AProduct.FirstOrDefault(o => o.ProductCode == data.ProductCode);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.AProduct.OrderBy(o => o.ProductCode).LastOrDefault();
                if (last != null)
                {
                    id = (last.ProductCode + 1);
                }
                data.ProductCode = id;
                db.AProduct.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public List<AProduct>? GetProduct()
        {
            return db.AProduct.AsNoTracking().ToList();
        }

        public async Task<List<AGender>?> GetGender()
        {
            return await db.AGender.AsNoTracking().ToListAsync();
        }

        public async Task SaveAContactCategory(AContactCategory data)
        {
            var exists = db.AContactCategory.FirstOrDefault(o => o.ContactCategoryId == data.ContactCategoryId);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.AContactCategory.OrderBy(o => o.ContactCategoryId).LastOrDefault();
                if (last != null)
                {
                    id = (last.ContactCategoryId + 1);
                }
                data.ContactCategoryId = id;
                db.AContactCategory.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveADistrict(ADistrict data)
        {
            var exists = db.ADistrict.FirstOrDefault(o => o.DistrictCode == data.DistrictCode);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ADistrict.OrderBy(o => o.DistrictCode).LastOrDefault();
                if (last != null)
                {
                    id = (last.DistrictCode + 1);
                }
                data.DistrictCode = id;
                db.ADistrict.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveADrugRegimen(ADrugRegimen data)
        {
            var exists = db.ADrugRegimen.FirstOrDefault(o => o.RegimenCode == data.RegimenCode);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ADrugRegimen.OrderBy(o => o.RegimenCode).LastOrDefault();
                if (last != null)
                {
                    id = (last.RegimenCode + 1);
                }
                data.RegimenCode = id;
                db.ADrugRegimen.Add(data);
                await db.SaveChangesAsync();
            }
        }
        public List<ARegion> GetARegion()
        {
            return db.ARegion.AsNoTracking().ToList();
        }
        public async Task SaveADrugRegimenCategory(ADrugRegimenCategory data)
        {
            var exists = db.ADrugRegimenCategory.FirstOrDefault(o => o.RegimenCategoryCode == data.RegimenCategoryCode);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ADrugRegimenCategory.OrderBy(o => o.RegimenCategoryCode).LastOrDefault();
                if (last != null)
                {
                    id = (Convert.ToInt32(last.RegimenCategoryCode + 1));
                }
                data.RegimenCategoryCode = Convert.ToInt16(id);
                db.ADrugRegimenCategory.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveADrugRegimenClassification(ADrugRegimenClassification data)
        {
            var exists = db.ADrugRegimenClassification.FirstOrDefault(o => o.RegimenClassificationCode == data.RegimenClassificationCode);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ADrugRegimenClassification.OrderBy(o => o.RegimenClassificationCode).LastOrDefault();
                if (last != null)
                {
                    id = (last.RegimenClassificationCode + 1);
                }
                data.RegimenClassificationCode = id;
                db.ADrugRegimenClassification.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveAFacilityLevelOfCare(AFacilityLevelOfCare data)
        {
            var exists = db.AFacilityLevelOfCare.FirstOrDefault(o => o.LevelOfCareCode == data.LevelOfCareCode);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.AFacilityLevelOfCare.OrderBy(o => o.LevelOfCareCode).LastOrDefault();
                if (last != null)
                {
                    id = (last.LevelOfCareCode + 1);
                }
                data.LevelOfCareCode = id;
                db.AFacilityLevelOfCare.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveAFacilityType(AFacilityType data)
        {
            //var exists = db.AFacilityType.FirstOrDefault(o => o.FacilityTypeId == data.FacilityTypeId);
            //if (exists != null)
            //{
            //    db.Entry(exists).CurrentValues.SetValues(data);
            //    db.Entry(exists).State = EntityState.Modified;
            //    await db.SaveChangesAsync();
            //}
            //else
            //{
            //    int id = 1;
            //    var last = db.AFacilityType.OrderBy(o => o.FacilityTypeId).LastOrDefault();
            //    if (last != null)
            //    {
            //        id = (last.FacilityTypeId + 1);
            //    }
            //    data.FacilityTypeId = id;
            //    db.AFacilityType.Add(data);
            //    await db.SaveChangesAsync();
            //}
        }

        public async Task SaveAGender(AGender data)
        {
            var exists = db.AGender.FirstOrDefault(o => o.GenderCode == data.GenderCode);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.AGender.OrderBy(o => o.GenderCode).LastOrDefault();
                if (last != null)
                {
                    id = (last.GenderCode + 1);
                }
                data.GenderCode = id;
                db.AGender.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveAImplimentingPartners(AImplimentingPartners data)
        {
            var exists = db.AImplimentingPartners.FirstOrDefault(o => o.ImplimentingPartnerCode == data.ImplimentingPartnerCode);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.AImplimentingPartners.OrderBy(o => o.ImplimentingPartnerCode).LastOrDefault();
                if (last != null)
                {
                    id = (last.ImplimentingPartnerCode + 1);
                }
                data.ImplimentingPartnerCode = id;
                db.AImplimentingPartners.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveAOrderStatus(AOrderStatus data)
        {
            var exists = db.AOrderStatus.FirstOrDefault(o => o.StatusId == data.StatusId);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.AOrderStatus.OrderBy(o => o.StatusId).LastOrDefault();
                if (last != null)
                {
                    id = (last.StatusId + 1);
                }
                data.StatusId = id;
                db.AOrderStatus.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveAOrderType(AOrderType data)
        {
            var exists = db.AOrderType.FirstOrDefault(o => o.OrderTypeId == data.OrderTypeId);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.AOrderType.OrderBy(o => o.OrderTypeId).LastOrDefault();
                if (last != null)
                {
                    id = (last.OrderTypeId + 1);
                }
                data.OrderTypeId = id;
                db.AOrderType.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveAOwnership(AOwnership data)
        {
            var exists = db.AOwnership.FirstOrDefault(o => o.OwnershipId == data.OwnershipId);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.AOwnership.OrderBy(o => o.OwnershipId).LastOrDefault();
                if (last != null)
                {
                    id = (last.OwnershipId + 1);
                }
                data.OwnershipId = id;
                db.AOwnership.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public Task SaveAPhysicalCountStatus(APhysicalCountStatus data)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAProductBasicUnit(ADrugBasicUnit data)
        {
            var exists = db.ADrugBasicUnit.FirstOrDefault(o => o.ItemCode == data.ItemCode);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                short id = 1;
                var last = db.ADrugBasicUnit.OrderBy(o => o.ItemCode).LastOrDefault();
                if (last != null)
                {
                    id = Convert.ToInt16((last.ItemCode + 1));
                }
                data.ItemCode = id;
                db.ADrugBasicUnit.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveAProductCategory(AProductCategory data)
        {
            var exists = db.AProductCategory.FirstOrDefault(o => o.CategoryCode == data.CategoryCode);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.AProductCategory.OrderBy(o => o.CategoryCode).LastOrDefault();
                if (last != null)
                {
                    id = (last.CategoryCode + 1);
                }
                data.CategoryCode = id;
                db.AProductCategory.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveAProductClassification(AProductClassification data)
        {
            var exists = db.AProductClassification.FirstOrDefault(o => o.Id == data.Id);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.AProductClassification.OrderBy(o => o.Id).LastOrDefault();
                if (last != null)
                {
                    id = (last.Id + 1);
                }
                data.Id = id;
                db.AProductClassification.Add(data);
                await db.SaveChangesAsync();
            }
        }


        public async Task SaveARegion(ARegion data)
        {
            var exists = db.ARegion.FirstOrDefault(o => o.RegionId == data.RegionId);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ARegion.OrderBy(o => o.RegionId).LastOrDefault();
                if (last != null)
                {
                    id = (Convert.ToInt32(last.RegionId) + 1);
                }
                data.RegionId = Convert.ToString(id);
                db.ARegion.Add(data);
                await db.SaveChangesAsync();
            }
        }

        //treatement
        #region
        public  List<ATreatment> GetTreatment()
        {
            return db.ATreatment.AsNoTracking().ToList();
        }

        public async Task SaveATreatment(ATreatment data)
        {
            var exists = db.ATreatment.FirstOrDefault(o => o.ConditionCode == data.ConditionCode);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ATreatment.OrderBy(o => o.ConditionCode).LastOrDefault();
                if (last != null)
                {
                    id = (last.ConditionCode + 1);
                }
                data.ConditionCode = id;
                db.ATreatment.Add(data);
                await db.SaveChangesAsync();
            }
        }
        #endregion

        public async Task SaveATreatmentCategory(ATreatmentCategory data)
        {
            var exists = db.ATreatmentCategory.FirstOrDefault(o => o.TreatmentCategoryId == data.TreatmentCategoryId);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ATreatmentCategory.OrderBy(o => o.TreatmentCategoryId).LastOrDefault();
                if (last != null)
                {
                    id = (last.TreatmentCategoryId + 1);
                }
                data.TreatmentCategoryId = id;
                db.ATreatmentCategory.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveCdcregion(ACdcregion data)
        {
            var exists = db.ACdcregion.FirstOrDefault(o => o.CdcregionId == data.CdcregionId);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ACdcregion.OrderBy(o => o.CdcregionId).LastOrDefault();
                if (last != null)
                {
                    id = (last.CdcregionId + 1);
                }
                data.CdcregionId = id;
                db.ACdcregion.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveDeliveryZone(ADeliveryZone data)
        {
            var exists = db.ADeliveryZone.FirstOrDefault(o => o.ZoneCode == data.ZoneCode);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ADeliveryZone.OrderBy(o => o.ZoneCode).LastOrDefault();
                if (last != null)
                {
                    id = (last.ZoneCode + 1);
                }
                data.ZoneCode = id;
                db.ADeliveryZone.Add(data);
                await db.SaveChangesAsync();
            }
        }

        //public List<ImageDTO> GetLogos()
        //{
        //    List<ImageDTO> images = new List<ImageDTO>();
        //    string path = hostingEnv.WebRootPath + $@"\Logo";
        //    if (System.IO.Directory.Exists(path))
        //    {
        //        var directoryfiles = System.IO.Directory.GetFiles(path);
        //        int count = 1;
        //        foreach (var item in directoryfiles)
        //        {
        //            //string imagePath = Path.Combine(path, item);
        //            if (System.IO.File.Exists(item))
        //            {
        //                var bytes = System.IO.File.ReadAllBytes(item);
        //                FileInfo fi = new FileInfo(item);
        //                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        //                string result = "data:image/" + fi.Extension.Replace(".", "") + ";base64," + base64String;
        //                ImageDTO image = new ImageDTO();
        //                image.ImageId = count;
        //                image.ImageString = result;
        //                image.ImageName = fi.Name;
        //                image.ImageExt = fi.Extension;
        //                images.Add(image);

        //                count++;
        //            }
        //        }
        //    }
        //    return images;
        //}

        //public List<ACycle> GetCycle()
        //{
        //    return db.ACycle.AsNoTracking().ToList();
        //}

        public async Task SaveCycle(ACycle data)
        {
            var exists = db.ACycle.FirstOrDefault(o => o.CycleId == data.CycleId);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ACycle.OrderBy(o => o.CycleId).LastOrDefault();
                if (last != null)
                {
                    id = (last.CycleId + 1);
                }
                data.CycleId = id;
                db.ACycle.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public List<AMonth> GetMonth()
        {
            return db.AMonth.AsNoTracking().ToList();
        }

      

        List<ADrugBasicUnit>? IUtilityService.GetBasicUnit()
        {
            return db.ADrugBasicUnit.AsNoTracking().ToList();
        }

        List<ASupplier>? IUtilityService.GetProductSupplier()
        {
            return db.ASupplier.AsNoTracking().ToList();
        }

        async Task<List<ASapBatchInformation>?> IUtilityService.GetProductQuantities()
        {
            return await db.ASapBatchInformation.AsNoTracking().ToListAsync();
        }

        public async Task<List<ALabCategory1>?> GetLabCategory1()
        {
            return await db.ALabCategory1.AsNoTracking().ToListAsync();
        }

        public async Task<List<ALabCategory2>?> GetLabCategory2()
        {
            return await db.ALabCategory2.AsNoTracking().ToListAsync();
        }

        public async Task<List<ALabCategory3>?> GetLabCategory3()
        {
            return await db.ALabCategory3.AsNoTracking().ToListAsync();
        }

        public async Task SaveLabCategory1(ALabCategory1 data)
        {
            var exists = db.ALabCategory1.FirstOrDefault(o => o.LabCat1Code == data.LabCat1Code);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ALabCategory1.OrderBy(o => o.LabCat1Code).LastOrDefault();
                if (last != null)
                {
                    id = (last.LabCat1Code + 1);
                }
                data.LabCat1Code = id;
                db.ALabCategory1.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveLabCategory2(ALabCategory2 data)
        {
            var exists = db.ALabCategory2.FirstOrDefault(o => o.LabCat2Code == data.LabCat2Code);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ALabCategory2.OrderBy(o => o.LabCat2Code).LastOrDefault();
                if (last != null)
                {
                    id = (last.LabCat2Code + 1);
                }
                data.LabCat2Code = id;
                db.ALabCategory2.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveLabCategory3(ALabCategory3 data)
        {
            var exists = db.ALabCategory3.FirstOrDefault(o => o.LabCat3Code == data.LabCat3Code);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ALabCategory3.OrderBy(o => o.LabCat3Code).LastOrDefault();
                if (last != null)
                {
                    id = (last.LabCat3Code + 1);
                }
                data.LabCat3Code = id;
                db.ALabCategory3.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveAProductQuantities(ASapBatchInformation data)
        {
            var exists = db.ASapBatchInformation.FirstOrDefault(o => o.Id == data.Id);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ASapBatchInformation.OrderBy(o => o.Id).LastOrDefault();
                if (last != null)
                {
                    id = (last.Id + 1);
                }
                data.Id = id;
                db.ASapBatchInformation.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveAProductSupplier(ASupplier data)
        {
            var exists = db.ASupplier.FirstOrDefault(o => o.SupplierCode == data.SupplierCode);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ASupplier.OrderBy(o => o.SupplierCode).LastOrDefault();
                if (last != null)
                {
                    id = (last.SupplierCode + 1);
                }
                data.SupplierCode = id;
                db.ASupplier.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<ATrimester>?> GetTrimester()
        {
            return await db.ATrimester.AsNoTracking().ToListAsync();
        }

        public async Task<List<SadrrOutcome>?> GetSADRROutcome()
        {
            return await db.SadrrOutcome
                .Where(o => o.ReportTypeId == 1 || o.ReportTypeId == null)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<SadrrOutcome>?> GetAEFIOutcome()
        {
            return await db.SadrrOutcome
                .Where(o => o.ReportTypeId == 2 || o.ReportTypeId == null)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<SadrrReaction>?> GetReactionSeriousness()
        {
            return await db.SadrrReaction
                .Where(o => o.ReportTypeId == 1)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<AMotherStatus>?> GetMotherStatus()
        {
            return await db.AMotherStatus.AsNoTracking().ToListAsync();
        }

        public async Task<List<AAgeGroups>?> GetAgeGroup()
        {
            return await db.AAgeGroups.AsNoTracking().ToListAsync();
        }

        public async Task<List<ADose>?> GetDose()
        {
            return await db.ADose.AsNoTracking().ToListAsync();
        }



        public async Task<List<APvsatus>?> GetPVStatus()
        {
            return await pvcontextdb.APvsatus.AsNoTracking().ToListAsync();
        }

        public async Task<List<APvreportingType>?> GetReportingType()
        {
            return await pvcontextdb.APvreportingType.AsNoTracking().ToListAsync();
        }

        public async Task<List<AAdverseEvent>?> GetAdverseEvent()
        {
            return await db.AAdverseEvent.AsNoTracking().ToListAsync();
        }
        public async Task SaveAAdverseEvent(AAdverseEvent data)
        {
            {
                var exists = db.AAdverseEvent.FirstOrDefault(o => o.AdverseEventId == data.AdverseEventId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.AAdverseEvent.OrderBy(o => o.AdverseEventId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.AdverseEventId + 1);
                    }
                    data.AdverseEventId = id;
                    db.AAdverseEvent.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task SaveAAgeGroups(AAgeGroups data)
        {
            {
                var exists = db.AAgeGroups.FirstOrDefault(o => o.AgeGroupId == data.AgeGroupId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.AAdverseEvent.OrderBy(o => o.AdverseEventId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.AdverseEventId + 1);
                    }
                    data.AgeGroupId = id;
                    db.AAgeGroups.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }

        //Audit section
        #region

        public async Task<List<AAuditSection>?> GetAuditSection()
        {
            return await db.AAuditSection.AsNoTracking().ToListAsync();
        }
        public async Task SaveAuditSection(AAuditSection data)
        {
            {
                var exists = db.AAuditSection.FirstOrDefault(o => o.AuditSectionId == data.AuditSectionId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.AAuditSection.OrderBy(o => o.AuditSectionId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.AuditSectionId + 1);
                    }
                    data.AuditSectionId = id;
                    db.AAuditSection.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion

        //authorisedrep
        #region

        public async Task<List<AAuthorizedRepresentative>?> GetAuthorizedRep()
        {
            return await db.AAuthorizedRepresentative.AsNoTracking().ToListAsync();
        }

        public async Task SaveAuthorizedRep(AAuthorizedRepresentative data)
        {
            {
                var exists = db.AAuthorizedRepresentative.FirstOrDefault(o => o.AuthorizedRepresentativeCode == data.AuthorizedRepresentativeCode);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.AAuthorizedRepresentative.OrderBy(o => o.AuthorizedRepresentativeCode).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.AuthorizedRepresentativeCode + 1);
                    }
                    data.AuthorizedRepresentativeCode = id;
                    db.AAuthorizedRepresentative.Add(data);
                    await db.SaveChangesAsync();
                }
            }

        }

        #endregion
        //ACAPACOMPLETIONSTATUS
        #region

        public async Task SaveACapaCompletionStatus(ACapaCompletionStatus data)
        {
            var exists = db.ACapaCompletionStatus.FirstOrDefault(o => o.CapaCompletionStatusId == data.CapaCompletionStatusId);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ACapaCompletionStatus.OrderBy(o => o.CapaCompletionStatusId).LastOrDefault();
                if (last != null)
                {
                    id = (last.CapaCompletionStatusId + 1);
                }
                data.CapaCompletionStatusId = id;
                db.ACapaCompletionStatus.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<ACapaCompletionStatus>?> GetACapaCompletionStatus()
        {
            return await db.ACapaCompletionStatus.AsNoTracking().ToListAsync();
        }

        #endregion

       // ACapaRegisterStatus

        #region
        public async Task SaveACapaRegisterStatus(ACapaRegisterStatus data)
        {
            var exists = db.ACapaRegisterStatus.FirstOrDefault(o => o.CapaRegisterStatusId == data.CapaRegisterStatusId);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ACapaRegisterStatus.OrderBy(o => o.CapaRegisterStatusId).LastOrDefault();
                if (last != null)
                {
                    id = (last.CapaRegisterStatusId + 1);
                }
                data.CapaRegisterStatusId = id;
                db.ACapaRegisterStatus.Add(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<ACapaRegisterStatus>?> GetACapaRegisterStatus()
        {
            return await db.ACapaRegisterStatus.AsNoTracking().ToListAsync();
        }

        #endregion
        public async Task SaveACdcregion(ACdcregion data)
        {
            var exists = db.ACdcregion.FirstOrDefault(o => o.CdcregionId == data.CdcregionId);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.ACdcregion.OrderBy(o => o.CdcregionId).LastOrDefault();
                if (last != null)
                {
                    id = (last.CdcregionId + 1);
                }
                data.CdcregionId = id;
                db.ACdcregion.Add(data);
                await db.SaveChangesAsync();
            }
        }

        

        //public async Task<List<AVillage>?> GetVillage()
        //{
        //    return await db.AVillage.AsNoTracking().ToListAsync();
        //}
        //public async Task SaveVillage(AVillage data )
        //{
        //    var exists = db.AVillage.FirstOrDefault(o => o.VillageId== data.VillageId);
        //    if (exists != null)
        //    {
        //        db.Entry(exists).CurrentValues.SetValues(data);
        //        db.Entry(exists).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        int id = 1;
        //        var last = db.AVillage.OrderBy(o => o.VillageId).LastOrDefault();
        //        if (last != null)
        //        {
        //            id = (last.VillageId + 1);
        //        }
        //        data.VillageId = id;
        //        db.AVillage.Add(data);
        //        await db.SaveChangesAsync();
        //    }
        //}

        //variation
        #region
        public async Task<List<AVariationStatus>?> GetVariation()
        {
            return await db.AVariationStatus.AsNoTracking().ToListAsync();
        }

        public async Task SaveVariation(AVariationStatus data)
        {
            var exists = db.AVariationStatus.FirstOrDefault(o => o.VariationStatusId == data.VariationStatusId);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.AVerificationMethod.OrderBy(o => o.VerificationMethodId).LastOrDefault();
                if (last != null)
                {
                    id = (last.VerificationMethodId + 1);
                }
                data.VariationStatusId = id;
                db.AVariationStatus.Add(data);
                await db.SaveChangesAsync();
            }
        }

        #endregion

        //VERIFICATION
        #region
        public async Task<List<AVerificationMethod>?> GetVerificationMethod()
        {
            return await db.AVerificationMethod.AsNoTracking().ToListAsync();
        }

        public async Task SaveVerificationMethod(AVerificationMethod data)
        {
            var exists = db.AVerificationMethod.FirstOrDefault(o => o.VerificationMethodId == data.VerificationMethodId);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.AVerificationMethod.OrderBy(o => o.VerificationMethodId).LastOrDefault();
                if (last != null)
                {
                    id = (last.VerificationMethodId + 1);
                }
                data.VerificationMethodId = id;
                db.AVerificationMethod.Add(data);
                await db.SaveChangesAsync();
            }
        }

        #endregion
        public async Task SaveAYesNo(AYesNo data)
        {
            var exists = db.AYesNo.FirstOrDefault(o => o.YesNoId == data.YesNoId);
            if (exists != null)
            {
                db.Entry(exists).CurrentValues.SetValues(data);
                db.Entry(exists).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                int id = 1;
                var last = db.AYesNo.OrderBy(o => o.YesNoId).LastOrDefault();
                if (last != null)
                {
                    id = (last.YesNoId + 1);
                }
                data.YesNoId = id;
                db.AYesNo.Add(data);
                await db.SaveChangesAsync();
            }
        }

        //Atimester
        #region
        public async Task SaveTrimester(ATrimester data)
        {
            {
                var exists = db.ATrimester.FirstOrDefault(o => o.TrimesterId == data.TrimesterId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.ATrimester.OrderBy(o => o.TrimesterId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.TrimesterId + 1);
                    }
                    data.TrimesterId = id;
                    db.ATrimester.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        ////public async Task<List<ATrimester>?> GetTrimmester()
        //{
        //    return await db.ATrimester.AsNoTracking().ToListAsync();
        //}
        #endregion
        //supplier
        #region
        public async Task<List<ASupplier>?> GetASupplier()
        {
            return await db.ASupplier.AsNoTracking().ToListAsync();
        }
        public async Task SaveASupplier(ASupplier data)
        {
            {
                var exists = db.ASupplier.FirstOrDefault(o => o.SupplierCode == data.SupplierCode);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.ASupplier.OrderBy(o => o.SupplierCode).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.SupplierCode + 1);
                    }
                    data.SupplierCode = id;
                    db.ASupplier.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion

        //COUNTY
        #region
        public async Task<List<ACounty>?> GetACounty()
        {
            return await db.ACounty.AsNoTracking().ToListAsync();
        }
        public async Task SaveACounty(ACounty data)
        {
            {
                var exists = db.ACounty.FirstOrDefault(o => o.CountyId == data.CountyId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    string id = "";
                    var last = db.ACounty.OrderBy(o => o.CountyId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.CountyId + 1);
                    }
                    data.CountyId = id;
                    db.ACounty.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion

        //subcountry
        //supplier
        #region
        public async Task<List<ASubcounty>?> GetASubcounty()
        {
            return await db.ASubcounty.AsNoTracking().ToListAsync();
        }
        public async Task SaveASubcounty(ASubcounty data)
        {
            {
                var exists = db.ASubcounty.FirstOrDefault(o => o.SubcountyId == data.SubcountyId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    string id = "";
                    var last = db.ASubcounty.OrderBy(o => o.SubcountyId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.SubcountyId + 1);
                    }
                    data.SubcountyId = id;
                    db.ASubcounty.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion

        //sectorchange
        #region
        public async Task<List<ASectorChange>?> GetASectorChange()
        {
            return await db.ASectorChange.AsNoTracking().ToListAsync();
        }
        public async Task SaveASectorChange(ASectorChange data)
        {
            {
                var exists = db.ASectorChange.FirstOrDefault(o => o.FacilityCode == data.FacilityCode);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id =1 ;
                    var last = db.ASectorChange.OrderBy(o => o.FacilityCode).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.FacilityCode + 1);
                    }
                    data.FacilityCode = id;
                    db.ASectorChange.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion

        //ASAPBATCH
        #region
        public async Task<List<ASapBatchInformation>?> GetASapBatchInformation()
        {
            return await db.ASapBatchInformation.AsNoTracking().ToListAsync();
        }
        public async Task SaveASapBatchInformation(ASapBatchInformation data)
        {
            {
                var exists = db.ASapBatchInformation.FirstOrDefault(o => o.Id == data.Id);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.ASapBatchInformation.OrderBy(o => o.Id).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.Id + 1);
                    }
                    data.Id = id;
                    db.ASapBatchInformation.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion
       // Release inst
        #region
        public async Task<List<AReleaseInstruction>?> GetReleaseInstruction()
        {
            return await db.AReleaseInstruction.AsNoTracking().ToListAsync();
        }
        public async Task SaveReleaseInstruction(AReleaseInstruction data)
        {
            {
                var exists = db.AReleaseInstruction.FirstOrDefault(o => o.ReleaseInstructionCode == data.ReleaseInstructionCode);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.AReleaseInstruction.OrderBy(o => o.ReleaseInstructionCode).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.ReleaseInstructionCode + 1);
                    }
                    data.ReleaseInstructionCode = id;
                    db.AReleaseInstruction.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion

        //Registation status
        #region
        public async Task<List<ARegistrationStatus>?> GetARegistrationStatus()
        {
            return await db.ARegistrationStatus.AsNoTracking().ToListAsync();
        }
        public async Task SaveARegistrationStatus(ARegistrationStatus data)
        {
            {
                var exists = db.ARegistrationStatus.FirstOrDefault(o => o.RegistrationStatusId == data.RegistrationStatusId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.ARegistrationStatus.OrderBy(o => o.RegistrationStatusId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.RegistrationStatusId + 1);
                    }
                    data.RegistrationStatusId = id;
                    db.ARegistrationStatus.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion
        //apvstatus
        public async Task SavePVStatus(APvsatus data)
        {
            {
                var exists = pvcontextdb.APvsatus.FirstOrDefault(o => o. PvstatusId== data.PvstatusId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = pvcontextdb.APvsatus.OrderBy(o => o.PvstatusId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.PvstatusId + 1);
                    }
                    data.PvstatusId = id;
                    pvcontextdb.APvsatus.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }

        //APVRegistation status
        #region
        public async Task<List<APvreportingType>?> GetAPVReporting()
        {
            return await pvcontextdb.APvreportingType .AsNoTracking().ToListAsync();
        }
        public async Task SaveAPVReporting(APvreportingType data)
        {
            {
                var exists = pvcontextdb.APvreportingType.FirstOrDefault(o => o.ReportTypeId == data.ReportTypeId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.ARegistrationStatus.OrderBy(o => o.RegistrationStatusId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.RegistrationStatusId + 1);
                    }
                    data.ReportTypeId = id;
                    pvcontextdb.APvreportingType.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion

        //ACLIENTTYPE
        #region
        public async Task<List<AClientType>?> GetAClientType()
        {
            return await db.AClientType.AsNoTracking().ToListAsync();
        }
        public async Task SaveAClientType(AClientType data)
        {
            {
                var exists = db.AClientType.FirstOrDefault(o => o.ClientTypeCode == data.ClientTypeCode);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.AClientType.OrderBy(o => o.ClientTypeCode).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.ClientTypeCode + 1);
                    }
                    data.ClientTypeCode = id;
                    db.AClientType.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion
        //ACommunicationmode
        #region
        public async Task<List<ACommunicationMode>?> GetACommunicationMode()
        {
            return await db.ACommunicationMode.AsNoTracking().ToListAsync();
        }
        public async Task SaveACommunicationMode(ACommunicationMode data)
        {
            {
                var exists = db.ACommunicationMode.FirstOrDefault(o => o.CommunicationModeId == data.CommunicationModeId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.ACommunicationMode.OrderBy(o => o.CommunicationModeId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.CommunicationModeId + 1);
                    }
                    data.CommunicationModeId = id;
                    db.ACommunicationMode.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion
        //AComPLAINTACTIONTAKEN
        #region
        public async Task<List<AComplaintActionTaken>?> GetAComplaintActionTaken()
        {
            return await db.AComplaintActionTaken.AsNoTracking().ToListAsync();
        }
        public async Task SaveAComplaintActionTaken(AComplaintActionTaken data)
        {
            {
                var exists = db.AComplaintActionTaken.FirstOrDefault(o => o.ActionTakenCode == data.ActionTakenCode);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.AComplaintActionTaken.OrderBy(o => o.ActionTakenCode).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.ActionTakenCode + 1);
                    }
                    data.ActionTakenCode = id;
                    db.AComplaintActionTaken.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion

        //AComPLAINTcategory
        #region
        public async Task<List<AComplaintCategory>?> GetAComplaintCategory()
        {
            return await db.AComplaintCategory.AsNoTracking().ToListAsync();
        }
        public async Task SaveAComplaintCategory(AComplaintCategory data)
        {
            {
                var exists = db.AComplaintCategory.FirstOrDefault(o => o.ComplaintCategoryCode == data.ComplaintCategoryCode);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.AComplaintCategory.OrderBy(o => o.ComplaintCategoryCode).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.ComplaintCategoryCode + 1);
                    }
                    data.ComplaintCategoryCode = id;
                    db.AComplaintCategory.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion
        //AComPLAINTclassification
        #region
        public async Task<List<AComplaintClassification>?> GetAComplaintClassification()
        {
            return await db.AComplaintClassification.AsNoTracking().ToListAsync();
        }
        public async Task SaveAComplaintClassification(AComplaintClassification data)
        {
            {
                var exists = db.AComplaintClassification.FirstOrDefault(o => o.ClassificationCode == data.ClassificationCode);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.AComplaintClassification.OrderBy(o => o.ClassificationCode).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.ClassificationCode + 1);
                    }
                    data.ClassificationCode = id;
                    db.AComplaintClassification.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion
        //AComPLAINTclassification
        #region
        public async Task<List<AComplaintConfirmationStatus>?> GetAComplaintConfirmationStatus()
        {
            return await db.AComplaintConfirmationStatus.AsNoTracking().ToListAsync();
        }
        public async Task SaveAComplaintConfirmationStatus(AComplaintConfirmationStatus data)
        {
            {
                var exists = db.AComplaintConfirmationStatus.FirstOrDefault(o => o.ComplaintConfirmationStatusId == data.ComplaintConfirmationStatusId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.AComplaintConfirmationStatus.OrderBy(o => o.ComplaintConfirmationStatusId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.ComplaintConfirmationStatusId + 1);
                    }
                    data.ComplaintConfirmationStatusId = id;
                    db.AComplaintConfirmationStatus.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion

        //AComPLAINTclassification
        #region
        public async Task<List<AComplaintReportingGroup>?> GetAComplaintReportingGroup()
        {
            return await db.AComplaintReportingGroup.AsNoTracking().ToListAsync();
        }
        public async Task SaveAComplaintReportingGroup(AComplaintReportingGroup data)
        {
            {
                var exists = db.AComplaintReportingGroup.FirstOrDefault(o => o.ReportingGroupId == data.ReportingGroupId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.AComplaintReportingGroup.OrderBy(o => o.ReportingGroupId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.ReportingGroupId + 1);
                    }
                    data.ReportingGroupId = id;
                    db.AComplaintReportingGroup.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion
        //AComPLAINTstatus
        #region
        public async Task<List<AComplaintStatus>?> GetAComplaintStatus()
        {
            return await db.AComplaintStatus.AsNoTracking().ToListAsync();
        }
        public async Task SaveAComplaintStatus(AComplaintStatus data)
        {
            {
                var exists = db.AComplaintStatus.FirstOrDefault(o => o.ComplaintStatusCode == data.ComplaintStatusCode);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.AComplaintStatus.OrderBy(o => o.ComplaintStatusCode).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.ComplaintStatusCode + 1);
                    }
                    data.ComplaintStatusCode = id;
                    db.AComplaintStatus.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion
        //AComPLetion time scale
        #region
        public async Task<List<ACompletionTimeScale>?> GetACompletionTimeScale()
        {
            return await db.ACompletionTimeScale.AsNoTracking().ToListAsync();
        }
        public async Task SaveACompletionTimeScale(ACompletionTimeScale data)
        {
            {
                var exists = db.ACompletionTimeScale.FirstOrDefault(o => o.CompletionTimeScaleId == data.CompletionTimeScaleId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.ACompletionTimeScale.OrderBy(o => o.CompletionTimeScaleId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.CompletionTimeScaleId + 1);
                    }
                    data.CompletionTimeScaleId = id;
                    db.ACompletionTimeScale.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion

        //AContacttitle
        #region
        public async Task<List<AContactTitle>?> GetAContactTitle()
        {
            return await db.AContactTitle.AsNoTracking().ToListAsync();
        }
        public async Task SaveAContactTitle(AContactTitle data)
        {
            {
                var exists = db.AContactTitle.FirstOrDefault(o => o.ContactTitleId == data.ContactTitleId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.AContactTitle.OrderBy(o => o.ContactTitleId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last. ContactTitleId+ 1);
                    }
                    data.ContactTitleId = id;
                    db.AContactTitle.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }
        #endregion

        //ACountry
        #region
        public async Task<List<ACountry>?> GetACountry()
        {
            return await db.ACountry.AsNoTracking().ToListAsync();
        }
        public async Task SaveACountry(ACountry data)
        {
            {
                var exists = db.ACountry.FirstOrDefault(o => o.CountryId == data.CountryId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.ACountry.OrderBy(o => o.CountryId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.CountryId + 1);
                    }
                    data.CountryId = id;
                    db.ACountry.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }

        //public List<ACycle> GetCycle()
        //{
        //    throw new NotImplementedException();
        //}
        #endregion

        //deliveryzone
        #region
        public async Task<List<ADeliveryZone>?> GetADeliveryZone()
        {
            return await db.ADeliveryZone.AsNoTracking().ToListAsync();
        }
        public async Task SaveADeliveryZone(ADeliveryZone data)
        {
            {
                var exists = db.ADeliveryZone.FirstOrDefault(o => o.ZoneCode == data.ZoneCode);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.ADeliveryZone.OrderBy(o => o.ZoneCode).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.ZoneCode + 1);
                    }
                    data.ZoneCode = id;
                    db.ADeliveryZone.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }


        #endregion

        //adose
        public async Task SaveDose(ADose data)
        {
            {
                var exists = db.ADose.FirstOrDefault(o => o.DoseTypeId == data.DoseTypeId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.ADose.OrderBy(o => o.DoseTypeId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.DoseTypeId + 1);
                    }
                    data.DoseTypeId = id;
                    db.ADose.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }

        //AInspectionStatus
        #region
        public async Task<List<AInspectionStatus>?> GetAInspectionStatus()
        {
            return await db.AInspectionStatus.AsNoTracking().ToListAsync();
        }
        public async Task SaveAInspectionStatus(AInspectionStatus data)
        {
            {
                var exists = db.AInspectionStatus.FirstOrDefault(o => o.InspectionStatusId == data.InspectionStatusId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.AInspectionStatus.OrderBy(o => o.InspectionStatusId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.InspectionStatusId + 1);
                    }
                    data.InspectionStatusId = id;
                    db.AInspectionStatus.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }


        #endregion
        //ALaboratory
        #region
        public async Task<List<ALaboratory>?> GetLab()
        {
            return await db.ALaboratory.AsNoTracking().ToListAsync();
        }
        public async Task SaveLab(ALaboratory data)
        {
            {
                var exists = db.ALaboratory.FirstOrDefault(o => o.LabCode == data.LabCode);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.ALaboratory.OrderBy(o => o.LabCode).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.LabCode + 1);
                    }
                    data.LabCode = id;
                    db.ALaboratory.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }


        #endregion

        //ALtr
        #region
        public async Task<List<ALtr>?> GetLtr()
        {
            return await db.ALtr.AsNoTracking().ToListAsync();
        }
        public async Task SaveLtr(ALtr data)
        {
            {
                var exists = db.ALtr.FirstOrDefault(o => o.LtrId == data.LtrId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.ALtr.OrderBy(o => o.LtrId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.LtrId + 1);
                    }
                    data.LtrId = id;
                    db.ALtr.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }


        #endregion

        //AMonth
        #region
        public async Task<List<AMonth>?> GetAMonth()
        {
            return await db.AMonth.AsNoTracking().ToListAsync();
        }
        public async Task SaveAMonth(AMonth data)
        {
            {
                var exists = db.AMonth.FirstOrDefault(o => o.MonthId == data.MonthId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.AMonth.OrderBy(o => o.MonthId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.MonthId + 1);
                    }
                    data.MonthId = id;
                    db.AMonth.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }


        #endregion

        //amotherstaus
        public async Task SaveAMotherStatus(AMotherStatus data)
        {
            {
                var exists = db.AMotherStatus.FirstOrDefault(o => o.MotherStatusId == data.MotherStatusId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.AMotherStatus.OrderBy(o => o.MotherStatusId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.MotherStatusId + 1);
                    }
                    data.MotherStatusId = id;
                    db.AMotherStatus.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }

        //Aorderstatus
        #region
        public async Task<List<AOrderStatus>?> GetAOrderStatus()
        {
            return await db.AOrderStatus.AsNoTracking().ToListAsync();
        }
        //public async Task SaveOrderStatus(AOrderStatus data)
        //{
        //    {
        //        var exists = db.AOrderStatus.FirstOrDefault(o => o.StatusId == data.StatusId);
        //        if (exists != null)
        //        {
        //            db.Entry(exists).CurrentValues.SetValues(data);
        //            db.Entry(exists).State = EntityState.Modified;
        //            await db.SaveChangesAsync();
        //        }
        //        else
        //        {
        //            int id = 1;
        //            var last = db.AOrderStatus.OrderBy(o => o.StatusId).LastOrDefault();
        //            if (last != null)
        //            {
        //                id = (last.StatusId + 1);
        //            }
        //            data.StatusId = id;
        //            db.AOrderStatus.Add(data);
        //            await db.SaveChangesAsync();
        //        }
        //    }
        //}


        #endregion

        //OWNERSHIP
        #region
        public async Task<List<AOwnership>?> GetAOwnership()
        {
            return await db.AOwnership.AsNoTracking().ToListAsync();
        }



        #endregion


        //ACYCLE
        #region
        public async Task<List<ACycle>?> GetACycle()
        {
            return await db.ACycle.AsNoTracking().ToListAsync();
        }
        public async Task SaveACycle(ACycle data)
        {
            {
                var exists = db.ACycle.FirstOrDefault(o => o.CycleId == data.CycleId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id = 1;
                    var last = db.ACycle.OrderBy(o => o.CycleId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.CycleId + 1);
                    }
                    data.CycleId = id;
                    db.ACycle.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }


        #endregion

        //AVillage
        #region
        public async Task<List<AVillage>?> GetAVillage()
        {
            return await db.AVillage.AsNoTracking().ToListAsync();
        }
        public async Task SaveAVillage(AVillage data)
        {
            {
                var exists = db.AVillage.FirstOrDefault(o => o.VillageId == data.VillageId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    string id = "";
                    var last = db.AVillage.OrderBy(o => o.VillageId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.VillageId + 1);
                    }
                    data.VillageId = id;
                    db.AVillage.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }


        #endregion

        //AVillage
        #region
        public async Task<List<AYesNo>?> GetYesNo()
        {
            return await db.AYesNo.AsNoTracking().ToListAsync();
        }
        //public List<AYesNo> GetYesNo()
        //{
        //    return db.AYesNo.AsNoTracking().ToList();
        //}
        public async Task SaveYesNo(AYesNo data)
        {
            {
                var exists = db.AYesNo.FirstOrDefault(o => o.YesNoId == data.YesNoId);
                if (exists != null)
                {
                    db.Entry(exists).CurrentValues.SetValues(data);
                    db.Entry(exists).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    int id =1;
                    var last = db.AYesNo.OrderBy(o => o.YesNoId).LastOrDefault();
                    if (last != null)
                    {
                        id = (last.YesNoId + 1);
                    }
                    data.YesNoId = id;
                    db.AYesNo.Add(data);
                    await db.SaveChangesAsync();
                }
            }
        }

       


        #endregion






    }
}

