const schema = {
  bsonType: 'object',
  required: [
    'username',
    'password_hash',
    'password_salt',
    'locked',
    'role',
    'login_attempts',
  ],
  properties: {
    _id: {
      bsonType: 'objectId',
    },
    username: {
      bsonType: 'string',
    },
    password_hash: {
      bsonType: 'binData',
    },
    password_salt: {
      bsonType: 'binData',
    },
    locked: {
      bsonType: 'bool',
    },
    role: {
      enum: ['User', 'SuperAdmin'],
    },
    login_attempts: {
      bsonType: 'int',
    },
    refresh_token: {
      bsonType: ['string', 'null'],
    },
    is_deleted: {
      bsonType: 'bool',
    },
  },
};

db.getSiblingDB('SkiService').createCollection('users', {
  validator: {
    $jsonSchema: schema,
  },
});
