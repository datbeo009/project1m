using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class UserBll
    {
        WebModel _dbContex = null;
        public UserBll()
        {
            _dbContex = new WebModel();
        }
        public List<Account> Gets()
        {
            return _dbContex.Accounts.Where(e=>e.Status == true).ToList();
        }
        public bool CreateOrUpdateUser (Account entity)
        {
            try
            {
                if(entity.AccountID == 0)
                {
                   _dbContex.Accounts.Add(entity);
                }
                else
                {
                    var user = _dbContex.Accounts.Find(entity.AccountID);
                    user.Username = entity.Username;
                    user.Password = entity.Password;
                    user.Phone = entity.Phone;
                    user.Address = entity.Address;
                    user.Role = entity.Role;
                    user.Gender = entity.Gender;
                    user.CreatedDate = entity.CreatedDate;
                    user.LastModifiedDate = entity.LastModifiedDate;
                }
                _dbContex.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool Register(Account entity)
        {
            try
            {
                var salt = Guid.NewGuid().ToString().Substring(0, 7);
                var pass = entity.Password;

                var passMD5 = Encryptor.MD5Hash(pass + salt);

                entity.Password = passMD5;
                entity.Salt = salt;

                _dbContex.Accounts.Add(entity);
                return _dbContex.SaveChanges() > 0;
                

            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool Login (string username,string pass)
        {
            //lấy user co username 
            var user = _dbContex.Accounts.SingleOrDefault(e => e.Username == username);


            if (user != null)
            {
                if (!user.Status)
                {
                    return false;
                    //
                }
                var salt = user.Salt;
                var password = Encryptor.MD5Hash(pass + salt);

                if (password == user.Password)
                {
                    return true;
                }
            }
            return false;

        }

        public Account User(string username)
        {
            return _dbContex.Accounts.SingleOrDefault(e => e.Username == username);

        }


        public bool DeleteUser(int id)
        {
            try
            {
                _dbContex.Accounts.Remove(_dbContex.Accounts.Find(id));
                _dbContex.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }
        public bool CheckExistUserName(string name)
        {
            return _dbContex.Accounts.Any(e => e.Username == name);
        }
            
    }
}
