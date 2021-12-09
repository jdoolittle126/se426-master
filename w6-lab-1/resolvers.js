const db = require('./db');

const Query = {
   items:() => db.items.list(),
   orders:() => db.orders.list(),
   orderById:(root,args,context,info) => {
      return db.orders.get(args.id);
   },
   itemById:(root,args,context,info) => {
      return db.items.get(args.id);
   }
};


const Mutation = {
   createItem:(root,args,context,info) => {
      return db.items.create({name:args.name,
         sku:args.sku,
         price:args.price,
         color:args.color,
         size:args.size})
   }
}

module.exports = { Query, Mutation }

/*
* query {
  orders {
    id,
    dateOrdered
    items {
      id,
      sku,
      name,
      price,
      color,
      size
    }
  }
}

query {
  orders {
    id,
    dateOrdered
    items {
      id,
      sku,
      name,
      price,
      color,
      size
    }
  }
}

mutation {
  createItem(sku:"BruceSku", name:"BruceTest", price:100, color:"green",size:"xLarge")
}
*
* */
