using FluentNHibernateDemo.Config;
using FluentNHibernateDemo.Entity;
using NHibernate;
using System;
using System.Collections.Generic;

namespace FluentNHibernateDemo.DAO
{
    class UserManage
    {
        public static UserManage Instance = new UserManage();
        /// <summary>
        /// 通过账号和密码查看用户是否存在
        /// </summary>
        /// <param name="uName">账号</param>
        /// <param name="psw">密码</param>
        /// <returns></returns>
        public User Login(string uName, string psw)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction ita = session.BeginTransaction())
                {
                    var iq = session.QueryOver<User>().Where(user => user.account == uName && user.password == psw);
                    IList<User> res = iq.List();
                    if (res.Count > 0)
                    {
                        return res[0];
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 通过账号和密码添加新的用户
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public bool add(string account, string password)
        {
            bool flag = false;
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction ita = session.BeginTransaction())
                {
                    User user = new User();
                    user.account = account;
                    user.password = password;
                    Object obj = session.Save(user);
                    ita.Commit();
                    if (obj != null)
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }
        /// <summary>
        /// 通过账号删除用户
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public bool Delete(string account, string password)
        {
            bool flag = false;
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction ita = session.BeginTransaction())
                {
                    try
                    {
                        var iq = session.QueryOver<User>().Where(user => user.account == account && user.password == password);
                        IList<User> res = iq.List();
               

                        session.Delete(res[0]);
                        //session.Delete("account", account);
                        ita.Commit();
                        flag = true;
                    }
                    catch (Exception)
                    {
                        flag = false;
                    }
                }
            }
            return flag;
        }
        /// <summary>
        /// 通过账号和旧的密码更新新的密码
        /// </summary>
        /// <param name="oldAccount">账号</param>
        /// <param name="oldPassword">旧的密码</param>
        /// <param name="mewPassword">新的密码</param>
        /// <returns></returns>
        public bool Updata(string oldAccount, string oldPassword, string newPassword)
        {
            bool flag = false;
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction ita = session.BeginTransaction())
                {
                    try
                    {
                        var iq = session.QueryOver<User>().Where(user => user.account == oldAccount && user.password == oldPassword);
                        IList<User> res = iq.List();
                        if (res.Count > 0)
                        {
                            res[0].password = newPassword;
                        }
                        ita.Commit();
                        flag = true;
                    }
                    catch (Exception)
                    {
                        flag = false;
                    }
                }
            }
            return flag;
        }
    }
}
