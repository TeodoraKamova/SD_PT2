using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;



namespace TestingLayer
{
    class FieldTest
    {
        private AppDbContext dbContext;
        private FieldContext fieldContext;
        DbContextOptionsBuilder builder;

       

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            dbContext = new AppDbContext(builder.Options);
            fieldContext = new FieldContext(dbContext);
        }

        [Test]
        public void TestCreate()
        {
            int fieldsBefore = fieldContext.ReadAll().Count();

            fieldContext.Create(new Field("sport"));

            int fieldsAfter = fieldContext.ReadAll().Count();

            Assert.IsTrue(fieldsBefore != fieldsAfter);
        }

        [Test]
        public void TestRead()
        {
            fieldContext.Create(new Field("cinema"));

            Field f = fieldContext.Read(1);

            Assert.That(f != null, "There is no record with id 1!");
        }

        [Test]
        public void TestUpdate()
        {
            fieldContext.Create(new Field("art"));

            Field f = fieldContext.Read(1);

            f.Name = "food";

            fieldContext.Update(f);

            Field f1 = fieldContext.Read(1);

            Assert.IsTrue(f1.Name == "food", "Update() does not change name!");
        }

        [Test]
        public void TestDelete()
        {
            fieldContext.Create(new Field("Delete"));

            int fieldsBeforeDeletion = fieldContext.ReadAll().Count();

            fieldContext.Delete(1);

            int fieldsAfterDeletion = fieldContext.ReadAll().Count();

            Assert.AreNotEqual(fieldsBeforeDeletion, fieldsAfterDeletion);
        }
    }
}
