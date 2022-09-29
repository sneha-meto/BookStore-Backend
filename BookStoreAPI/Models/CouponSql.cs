using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class CouponSql : ICoupon
    {
        SqlCommand comm;
        SqlConnection conn;

        public CouponSql()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public bool ActivateCoupon(int id, bool activate)
        {
            int actBit = activate ? 1 : 0;
            comm.CommandText = "update Coupon set Active = "+actBit+" where CouponId="+id+";";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            if (activate) return true;
            else return false;
        }

        public void AddCoupon(Coupon coupon)
        {
            int actBit = coupon.Active ? 1 : 0;
            comm.CommandText = "insert into Coupon values ('"+coupon.CouponCode+"', "+coupon.Discount+",'"+coupon.Description+"',"+actBit+")";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Coupon> GetActiveCoupons()
        {
            List<Coupon> couponList = new List<Coupon>();
            comm.CommandText = "select * from Coupon where Active=1";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int couponId = Convert.ToInt32(reader["CouponId"]);
                string couponCode = reader["CouponCode"].ToString();
                float discount = float.Parse(reader["Discount"].ToString());
                string description = reader["Description"].ToString();
                bool active = Convert.ToBoolean(reader["Active"]);

                Coupon coupon = new Coupon(couponId, couponCode, discount, description, active);
                couponList.Add(coupon);
            }
            conn.Close();
            return couponList;
        }

        public List<Coupon> GetCoupons()
        {
            List<Coupon> couponList = new List<Coupon>();
            comm.CommandText = "select * from Coupon";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int couponId = Convert.ToInt32(reader["CouponId"]);
                string couponCode = reader["CouponCode"].ToString();
                float discount= float.Parse(reader["Discount"].ToString());
                string description=reader["Description"].ToString();
                bool active = Convert.ToBoolean(reader["Active"]);

                Coupon coupon = new Coupon(couponId, couponCode, discount, description, active);
                couponList.Add(coupon);
            }
            conn.Close();
            return couponList;
        }
    }
}