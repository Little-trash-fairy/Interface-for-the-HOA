﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Home_associat.DataBase.model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Homeowners_AssociationEntities : DbContext
    {
        public Homeowners_AssociationEntities()
            : base("name=Homeowners_AssociationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Apartment_number> Apartment_number { get; set; }
        public virtual DbSet<Benefits> Benefits { get; set; }
        public virtual DbSet<Building> Building { get; set; }
        public virtual DbSet<Counter> Counter { get; set; }
        public virtual DbSet<Flat> Flat { get; set; }
        public virtual DbSet<List_of_services> List_of_services { get; set; }
        public virtual DbSet<Monthly_bill> Monthly_bill { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<Rate> Rate { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<Tenant_of_flat> Tenant_of_flat { get; set; }
        public virtual DbSet<Adress> Adress { get; set; }
        public virtual DbSet<Flat_owner> Flat_owner { get; set; }
        public virtual DbSet<Person_view> Person_view { get; set; }
        public virtual DbSet<Tenant> Tenant { get; set; }
    
        public virtual int createRandomString(Nullable<int> minLength, Nullable<int> maxLength, string chars, ObjectParameter randomString)
        {
            var minLengthParameter = minLength.HasValue ?
                new ObjectParameter("minLength", minLength) :
                new ObjectParameter("minLength", typeof(int));
    
            var maxLengthParameter = maxLength.HasValue ?
                new ObjectParameter("maxLength", maxLength) :
                new ObjectParameter("maxLength", typeof(int));
    
            var charsParameter = chars != null ?
                new ObjectParameter("chars", chars) :
                new ObjectParameter("chars", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("createRandomString", minLengthParameter, maxLengthParameter, charsParameter, randomString);
        }
    
        public virtual int FillApartNumb(Nullable<int> max_row, Nullable<int> start_id)
        {
            var max_rowParameter = max_row.HasValue ?
                new ObjectParameter("max_row", max_row) :
                new ObjectParameter("max_row", typeof(int));
    
            var start_idParameter = start_id.HasValue ?
                new ObjectParameter("Start_id", start_id) :
                new ObjectParameter("Start_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FillApartNumb", max_rowParameter, start_idParameter);
        }
    
        public virtual int FillBenefits(Nullable<int> max_row, Nullable<int> start_id)
        {
            var max_rowParameter = max_row.HasValue ?
                new ObjectParameter("max_row", max_row) :
                new ObjectParameter("max_row", typeof(int));
    
            var start_idParameter = start_id.HasValue ?
                new ObjectParameter("Start_id", start_id) :
                new ObjectParameter("Start_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FillBenefits", max_rowParameter, start_idParameter);
        }
    
        public virtual int FillBuilding(Nullable<int> max_row, Nullable<int> start_id)
        {
            var max_rowParameter = max_row.HasValue ?
                new ObjectParameter("max_row", max_row) :
                new ObjectParameter("max_row", typeof(int));
    
            var start_idParameter = start_id.HasValue ?
                new ObjectParameter("Start_id", start_id) :
                new ObjectParameter("Start_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FillBuilding", max_rowParameter, start_idParameter);
        }
    
        public virtual int FillCounter(Nullable<int> max_row, Nullable<int> start_id)
        {
            var max_rowParameter = max_row.HasValue ?
                new ObjectParameter("max_row", max_row) :
                new ObjectParameter("max_row", typeof(int));
    
            var start_idParameter = start_id.HasValue ?
                new ObjectParameter("Start_id", start_id) :
                new ObjectParameter("Start_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FillCounter", max_rowParameter, start_idParameter);
        }
    
        public virtual int FillFlat(Nullable<int> max_row, Nullable<int> start_id)
        {
            var max_rowParameter = max_row.HasValue ?
                new ObjectParameter("max_row", max_row) :
                new ObjectParameter("max_row", typeof(int));
    
            var start_idParameter = start_id.HasValue ?
                new ObjectParameter("Start_id", start_id) :
                new ObjectParameter("Start_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FillFlat", max_rowParameter, start_idParameter);
        }
    
        public virtual int FillListOfServices(Nullable<int> max_row, Nullable<int> start_id)
        {
            var max_rowParameter = max_row.HasValue ?
                new ObjectParameter("max_row", max_row) :
                new ObjectParameter("max_row", typeof(int));
    
            var start_idParameter = start_id.HasValue ?
                new ObjectParameter("Start_id", start_id) :
                new ObjectParameter("Start_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FillListOfServices", max_rowParameter, start_idParameter);
        }
    
        public virtual int FillMonthlyBill(Nullable<int> max_row, Nullable<int> start_id)
        {
            var max_rowParameter = max_row.HasValue ?
                new ObjectParameter("max_row", max_row) :
                new ObjectParameter("max_row", typeof(int));
    
            var start_idParameter = start_id.HasValue ?
                new ObjectParameter("Start_id", start_id) :
                new ObjectParameter("Start_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FillMonthlyBill", max_rowParameter, start_idParameter);
        }
    
        public virtual int FillPerson(Nullable<int> max_row, Nullable<int> start_id)
        {
            var max_rowParameter = max_row.HasValue ?
                new ObjectParameter("max_row", max_row) :
                new ObjectParameter("max_row", typeof(int));
    
            var start_idParameter = start_id.HasValue ?
                new ObjectParameter("Start_id", start_id) :
                new ObjectParameter("Start_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FillPerson", max_rowParameter, start_idParameter);
        }
    
        public virtual int FillProvider(Nullable<int> max_row, Nullable<int> start_id)
        {
            var max_rowParameter = max_row.HasValue ?
                new ObjectParameter("max_row", max_row) :
                new ObjectParameter("max_row", typeof(int));
    
            var start_idParameter = start_id.HasValue ?
                new ObjectParameter("Start_id", start_id) :
                new ObjectParameter("Start_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FillProvider", max_rowParameter, start_idParameter);
        }
    
        public virtual int FillRandValue(Nullable<int> max_row, Nullable<int> start_id)
        {
            var max_rowParameter = max_row.HasValue ?
                new ObjectParameter("max_row", max_row) :
                new ObjectParameter("max_row", typeof(int));
    
            var start_idParameter = start_id.HasValue ?
                new ObjectParameter("Start_id", start_id) :
                new ObjectParameter("Start_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FillRandValue", max_rowParameter, start_idParameter);
        }
    
        public virtual int FillRate(Nullable<int> max_row, Nullable<int> start_id)
        {
            var max_rowParameter = max_row.HasValue ?
                new ObjectParameter("max_row", max_row) :
                new ObjectParameter("max_row", typeof(int));
    
            var start_idParameter = start_id.HasValue ?
                new ObjectParameter("Start_id", start_id) :
                new ObjectParameter("Start_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FillRate", max_rowParameter, start_idParameter);
        }
    
        public virtual int FillService(Nullable<int> max_row, Nullable<int> start_id)
        {
            var max_rowParameter = max_row.HasValue ?
                new ObjectParameter("max_row", max_row) :
                new ObjectParameter("max_row", typeof(int));
    
            var start_idParameter = start_id.HasValue ?
                new ObjectParameter("Start_id", start_id) :
                new ObjectParameter("Start_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FillService", max_rowParameter, start_idParameter);
        }
    
        public virtual int FillTenantOfFlat(Nullable<int> max_row, Nullable<int> start_id)
        {
            var max_rowParameter = max_row.HasValue ?
                new ObjectParameter("max_row", max_row) :
                new ObjectParameter("max_row", typeof(int));
    
            var start_idParameter = start_id.HasValue ?
                new ObjectParameter("Start_id", start_id) :
                new ObjectParameter("Start_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FillTenantOfFlat", max_rowParameter, start_idParameter);
        }
    
        public virtual int FillUnit(Nullable<int> max_row, Nullable<int> start_id)
        {
            var max_rowParameter = max_row.HasValue ?
                new ObjectParameter("max_row", max_row) :
                new ObjectParameter("max_row", typeof(int));
    
            var start_idParameter = start_id.HasValue ?
                new ObjectParameter("Start_id", start_id) :
                new ObjectParameter("Start_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FillUnit", max_rowParameter, start_idParameter);
        }
    
        public virtual int randDate(ObjectParameter rndDate)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("randDate", rndDate);
        }
    
        public virtual int randomInt(Nullable<int> inputSize, ObjectParameter outputInteger)
        {
            var inputSizeParameter = inputSize.HasValue ?
                new ObjectParameter("inputSize", inputSize) :
                new ObjectParameter("inputSize", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("randomInt", inputSizeParameter, outputInteger);
        }
    }
}
