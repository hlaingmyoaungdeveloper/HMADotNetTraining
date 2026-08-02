using Domain.models;
using June2026.OCMSDatabase.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.features.Enrollment;

public class EnrollmentService
{
    private readonly AppDbContext _db;

    public EnrollmentService()
    {
        _db = new AppDbContext();
    }

    public EnrollmentListResponseModel GetEnrollments(EnrollmentListRequestModel model)
    {
        var enrollments = _db.TblEnrollments.Select(x => new EnrollmentModel
        {
            SubClassId = x.SubClassId,
            StudentName = x.StudentName,
            StudentContact = x.StudentContact,
            PaymentInfo = x.PaymentInfo,
            Status = x.Status,
            CreatedDateTime = x.CreatedDateTime,
            CreatedBy = x.CreatedBy,
            ModifiedDateTime = x.ModifiedDateTime,
            ModifiedBy = x.ModifiedBy
        }).ToList();

        return new EnrollmentListResponseModel
        {
            IsSuccess = true,
            Message = "Successfully get Enrollment",
            Enrollments = enrollments
        };
    }

    public EnrollmentEditResponseModel GetEnrollment(EnrollmentEditRequestModel model)
    {
        var enrollment = _db.TblEnrollments.FirstOrDefault(x => x.EnrollmentId == model.EnrollmentId);
        if (enrollment is null)
        {
            return new EnrollmentEditResponseModel
            {
                Message = "Enrollment doesn't exist"
            };
        }
        return new EnrollmentEditResponseModel
        {
            IsSuccess = true,
            Message = "Successfully get Enrollment",
            SubClassId = enrollment.SubClassId,
            StudentName = enrollment.StudentName,
            StudentContact = enrollment.StudentContact,
            PaymentInfo = enrollment.PaymentInfo,
            Status = enrollment.Status,
            CreatedDateTime = enrollment.CreatedDateTime,
            CreatedBy = enrollment.CreatedBy,
            ModifiedDateTime = enrollment.ModifiedDateTime,
            ModifiedBy = enrollment.ModifiedBy
        };
    }

    public EnrollmentCreateResponseModel CreateEnrollment(EnrollmentCreateRequestModel model)
    {
        var subClass = _db.TblSubClasses.FirstOrDefault(x => x.SubClassId  == model.SubClassId);
        if (subClass is null)
        {
            return new EnrollmentCreateResponseModel
            {
                IsSuccess = false,
                Message = "SubClass doesn't exist"
            };
        }
        
        if (subClass.IsDelete)
        {
            return new EnrollmentCreateResponseModel
            {
                IsSuccess = false,
                Message = "Cannot enroll in a deleted SubClass."
            };
        }
        
        if (subClass.StudentLimit <= subClass.StudentCount)
        {
            return new EnrollmentCreateResponseModel
            {
                IsSuccess = false,
                Message = "StudentLimit is full"
            };
        }
        TblEnrollment enrollment = new TblEnrollment()
        {
            SubClassId = model.SubClassId,
            StudentName = model.StudentName,
            StudentContact = model.StudentContact,
            PaymentInfo = model.PaymentInfo,
            Status = model.Status,
            CreatedDateTime = DateTime.Now,
            CreatedBy = model.CreatedBy,
            ModifiedDateTime = DateTime.Now,
            ModifiedBy = model.ModifiedBy
        };
        _db.Add(enrollment);
        subClass.StudentCount += 1;
        int result = _db.SaveChanges();
    
        return new EnrollmentCreateResponseModel
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Successfully created Enrollment" : "Failed to create Enrollment"
        };
    }

}
