const schema = {
  bsonType: 'object',
  required: ['days', 'name'],
  properties: {
    _id: {
      bsonType: 'objectId',
    },
    days: {
      bsonType: 'int',
    },
    name: {
      bsonType: 'string',
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
