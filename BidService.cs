using Database.Data;
using Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class BidService
    {
        private readonly ApplicationDbContext _db;

        public BidService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Bids GetUserLastBid(string userID, int auctionID)
        {
            var  userBids = _db.Bids.Where(b => b.UserID == userID).ToList();
            var userLastBid = userBids.Where(b => b.AuctionID == auctionID).FirstOrDefault();
                if (userLastBid != null)
                {
                    return userLastBid;
                }

            return null;
        }
        public List<Bids> GetAllUserBids(string userID)
        {
            List<Bids> allUserBids = new();
            List<Bids> bids = _db.Bids.ToList();
            foreach (var bid in bids)
            {
                if (bid.UserID == userID)
                {
                    allUserBids.Add(bid);
                }
            }
            return allUserBids;
        }
    }
}
