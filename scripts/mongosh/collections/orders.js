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
    name: {
      bsonType: 'string',
    },
    email: {
      bsonType: 'string',
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
