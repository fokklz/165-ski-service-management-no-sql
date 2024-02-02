const schema = {
  bsonType: 'object',
  required: ['days', 'name'],
  properties: {
    _id: {
      bsonType: 'objectId',
    },
    days: {
      bsonType: 'int',
      minimum: 1,
      maximum: 365,
    },
    name: {
      bsonType: 'string',
      minLength: 3,
    },
    is_deleted: {
      bsonType: 'bool',
    },
  },
};

db.getSiblingDB('SkiService').createCollection('priorities', {
  validator: {
    $jsonSchema: schema,
  },
});
