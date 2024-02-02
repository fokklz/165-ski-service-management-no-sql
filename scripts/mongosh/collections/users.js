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
      pattern: '^[a-zA-Z0-9._ -]{3,}$',
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
      minimum: 0,
      maximum: 3,
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
