const skiServiceDb = db.getSiblingDB('SkiService');

skiServiceDb.orders.createIndex({
  state_id: 1,
  priority_id: 1,
  user_id: 1,
  created: 1,
});
skiServiceDb.users.createIndex({ username: 1 }, { unique: true });
