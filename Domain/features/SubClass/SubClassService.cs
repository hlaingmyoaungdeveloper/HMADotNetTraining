using Domain.models;
using June2026.OCMSDatabase.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.features.SubClass;

public class SubClassService
{
    private readonly AppDbContext _db;

    public SubClassService()
    {
        _db = new AppDbContext();
    }

    public SubClassListResponseModel GetSubClasses(SubClassListRequestModel model)
    {
        //var lst = _db.TblSubClasses.ToList();
        //List<SubClassModel> Classes = new List<SubClassModel>();

        //foreach (var item in lst)
        //{
        //    SubClassModel classes = new SubClassModel
        //    {

        //    };
        //    Classes.Add(classes);
        //}
        //SubClasses = Classes,
        var SubClasses = _db.TblSubClasses
            .Where(x => x.IsDelete == false)
            .Select(x => new SubClassModel
        {
            ClassName = x.ClassName,
            Location = x.Location,
            OpenDate = x.OpenDate,
            StudentLimit = x.StudentLimit,
            StudentCount = x.StudentCount,
            OpenTime = x.OpenTime,
            CreatedDateTime = x.CreatedDateTime,
            CreatedBy = x.CreatedBy,
            ModifiedDateTime = x.ModifiedDateTime,
            ModifiedBy = x.ModifiedBy

        }).ToList();

        return new SubClassListResponseModel
        {
            IsSuccess = true,
            Message = "Successfully get SubClass",
            SubClasses = SubClasses
        };
    }

    public SubClassEditResponseModel GetSubClass(SubClassEditRequestModel model)
    {
        var subClass = _db.TblSubClasses.FirstOrDefault(x => x.SubClassId == model.SubClassId);
        if (subClass is null)
        {
            return new SubClassEditResponseModel
            {
                Message = "SubClass doesn't exist"
            };
        }
        return new SubClassEditResponseModel
        {
            IsSuccess = true,
            Message = "Successfully get SubClass",
            ClassName = subClass.ClassName,
            Location = subClass.Location,
            OpenDate = subClass.OpenDate,
            StudentLimit = subClass.StudentLimit,
            StudentCount = subClass.StudentCount,
            OpenTime = subClass.OpenTime,
            CreatedDateTime = subClass.CreatedDateTime,
            CreatedBy = subClass.CreatedBy,
            ModifiedDateTime = subClass.ModifiedDateTime,
            ModifiedBy = subClass.ModifiedBy
        };
    }

    public SubClassCreateResponseModel CreateSubClass(SubClassCreateRequestModel model)
    {
        TblSubClass subClass = new TblSubClass()
        {
            ClassName = model.ClassName,
            Location = model.Location,
            OpenDate = model.OpenDate,
            StudentLimit = model.StudentLimit,
            StudentCount = 0,
            OpenTime = model.OpenTime,
            CreatedDateTime = DateTime.Now,
            CreatedBy = model.CreatedBy,
            ModifiedDateTime = DateTime.Now,
            ModifiedBy = model.ModifiedBy
        };
        _db.Add(subClass);
        int result = _db.SaveChanges();
        return new SubClassCreateResponseModel
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Successfully created SubClass" : "Failed to create SubClass"
        };
    }

    public SubClassPatchResponseModel PatchSubClass(int id,SubClassPatchRequestModel model)
    {
        var subClass = _db.TblSubClasses.FirstOrDefault(x => x.SubClassId == id);
        if (subClass is null)
        {
            return new SubClassPatchResponseModel
            {
                Message = "SubClass doesn't exist"
            };
        }
        if (!string.IsNullOrEmpty(model.ClassName))
        {
            subClass.ClassName = model.ClassName;
        }

        if(!string.IsNullOrEmpty(model.Location))
        {
            subClass.Location = model.Location;
        }

        if (model.StudentLimit != null && model.StudentLimit > subClass.StudentCount)
        {
            subClass.StudentLimit = model.StudentLimit;
        }

     
        if (model.OpenDate != null)
        {
            subClass.OpenDate = model.OpenDate;
        }

     
        if (model.OpenTime != null)
        {
            subClass.OpenTime = model.OpenTime;
        }

        subClass.ModifiedDateTime = DateTime.Now;
        int result = _db.SaveChanges();
        return new SubClassPatchResponseModel
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Successfully updated SubClass" : "Failed to update SubClass"

        };
    }

    public SubClassDeleteResponseModel DeleteSubClass(SubClassDeleteRequestModel model)
    {
        var subClass = _db.TblSubClasses.FirstOrDefault(x => x.SubClassId == model.SubClassId);
        if (subClass is null)
        {
            return new SubClassDeleteResponseModel
            {
                Message = "SubClass doesn't exist"
            };
        }
        
        var hasEnrollments = _db.TblEnrollments.Any(x => x.SubClassId == model.SubClassId);
        if (hasEnrollments)
        {
            return new SubClassDeleteResponseModel
            {
                IsSuccess = false,
                Message = "Cannot delete SubClass because it has enrollments."
            };
        }
        
        subClass.IsDelete = true;
        int result = _db.SaveChanges();
        return new SubClassDeleteResponseModel
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Successfully deleted SubClass" : "Failed to delete"
        };
    }

}
