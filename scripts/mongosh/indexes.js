const skiServiceDb = db.getSiblingDB('SkiService');

skiServiceDb.orders.createIndex({
  state_id: 1,
});
skiServiceDb.orders.createIndex({
  priority_id: 1,
});
skiServiceDb.orders.createIndex({
  created: 1,
});
skiServiceDb.orders.createIndex({
  user_id: 1,
});
skiServiceDb.users.createIndex({ username: 1 }, { unique: true });

skiServiceDb.services.createIndex({ name: 1 }, { unique: true });
skiServiceDb.priorities.createIndex({ name: 1 }, { unique: true });
skiServiceDb.states.createIndex({ name: 1 }, { unique: true });
