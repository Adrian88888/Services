﻿using Database.Data;
using System.Linq;

namespace Services
{
    public class BalanceService
    {
        private readonly ApplicationDbContext _db;
        public BalanceService(ApplicationDbContext db)
        {
            _db = db;
        }
        public int GetUserBalance(string userID)
        {
            var Balance = 0;
            if (_db.Deposits.Any(d => d.UserID == userID))
            {
                Balance = _db.Deposits.FirstOrDefault(x => x.UserID == userID).Balance;
            }
            return Balance;
        }
    }
}
