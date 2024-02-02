const schema = {
  bsonType: 'object',
  required: [
    'name',
    'email',
    'phone',
    'priority_id',
    'service_id',
    'state_id',
    'created',
  ],
  properties: {
    _id: {
      bsonType: 'objectId',
    },
    email: {
      bsonType: 'string',
      pattern: '^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$',
    },
    phone: {
      bsonType: 'string',
      pattern: '^(+d{1,2}s)?(?d{3})?[s.-]?d{3}[s.-]?d{4}$',
    },
    phone: {
      bsonType: 'string',
    },
    priority_id: {
      bsonType: 'objectId',
    },
    service_id: {
      bsonType: 'objectId',
    },
    state_id: {
      bsonType: 'objectId',
    },
    user_id: {
      bsonType: ['objectId', 'null'],
    },
    created: {
      bsonType: 'date',
    },
    note: {
      bsonType: ['string', 'null'],
    },
    is_deleted: {
      bsonType: 'bool',
    },
  },
};

db.getSiblingDB('SkiService').createCollection('orders', {
  validator: {
    $jsonSchema: schema,
  },
});
