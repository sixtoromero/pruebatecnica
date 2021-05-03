using ALPHA.Domain.Entity;
using ALPHA.InfraStructure.DAL;
using ALPHA.InfraStructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ALPHA.Test
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public async void GetAsyncByIdUserNoRegister()
        {
            //Preparaci�n
            Exception expectedException = null;
            DbContextOptions<ALPHADataContext> options = new DbContextOptions<ALPHADataContext>();
            UserRepository userRep = new UserRepository(options);
            int UserId = 4;

            //Prueba
            try
            {
                await userRep.GetAsync(UserId);
                Assert.Fail("Un error debi� ser arrojado");
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Verificaci�n
            Assert.IsTrue(expectedException is ApplicationException);
            Assert.AreEqual("La consulta no arrojo ning�n resultado con ese UserId", expectedException.Message);

        }

        [TestMethod]
        public async void InsertAsync()
        {
            //Preparaci�n
            Exception expectedException = null;
            DbContextOptions<ALPHADataContext> options = new DbContextOptions<ALPHADataContext>();
            UserRepository userRep = new UserRepository(options);
            User model = new User();

            model.Id = 0;
            model.Names = "User test";
            model.Surnames = "Test";
            model.Password = "123";
            model.Status = "A";
            model.RolId = 3;

            //Prueba
            try
            {
                await userRep.InsertAsync(model);
                Assert.Fail("Se debe insertar el registro");
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Verificaci�n
            Assert.IsTrue(expectedException is ApplicationException);
            Assert.AreEqual("El registro debi� ser insertado", expectedException.Message);
        }

        [TestMethod]
        public async void UpdateAsync()
        {
            //Preparaci�n
            Exception expectedException = null;
            DbContextOptions<ALPHADataContext> options = new DbContextOptions<ALPHADataContext>();
            UserRepository userRep = new UserRepository(options);
            User model = new User();

            model.Id = 2;
            model.Names = "User test";
            model.Surnames = "Test";
            model.Password = "123";
            model.Status = "A";
            model.RolId = 3;

            //Prueba
            try
            {
                await userRep.UpdateAsync(model);
                Assert.Fail("Se debe actualizar el registro");
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Verificaci�n
            Assert.IsTrue(expectedException is ApplicationException);
            Assert.AreEqual("El registro debi� ser actualizado", expectedException.Message);
        }

        [TestMethod]
        public async void DeleteAsync()
        {
            //Preparaci�n
            Exception expectedException = null;
            DbContextOptions<ALPHADataContext> options = new DbContextOptions<ALPHADataContext>();
            UserRepository userRep = new UserRepository(options);
            var Id = 4;

            //Prueba
            try
            {
                await userRep.DeleteAsync(Id);
                Assert.Fail("Se debe eliminar el registro");
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Verificaci�n
            Assert.IsTrue(expectedException is ApplicationException);
            Assert.AreEqual("El registro debi� ser eliminado", expectedException.Message);
        }


    }
}
