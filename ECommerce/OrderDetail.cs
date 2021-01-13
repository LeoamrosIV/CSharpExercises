using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ECommerce
{
    class OrderDetail
    {
        private int _id;
        private int _orderId;
        private int _articleId;
        private double _price;
        private int _articleAmount;

        public int Id { get => _id; }
        public int OrderId { get => _orderId; }
        public int ArticleId { get => _articleId; }
        public double Price { get => _price; }
        public int ArticleAmount { get => _articleAmount; }

        public OrderDetail(int orderId, int articleId, int articleAmount)
        {
            this._orderId = orderId;
            this._articleId = articleId;
            this._articleAmount = articleAmount;
        }
    }
}