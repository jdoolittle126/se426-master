const { DataStore } = require('notarealdb');

const store = new DataStore('./data');

module.exports = {
   items:store.collection('items'),
   orders:store.collection('orders')
};