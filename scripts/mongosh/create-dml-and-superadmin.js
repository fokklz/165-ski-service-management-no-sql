const skiServiceDb = db.getSiblingDB('SkiService');

db.getSiblingDB('admin').createUser({
  user: 'superadmin',
  pwd: 'superadmin',
  roles: ['root'],
});

skiServiceDb.createRole({
  role: 'DMLRole',
  privileges: [
    {
      resource: { db: 'SkiService', collection: '' },
      actions: ['find', 'insert', 'update', 'remove'],
    },
  ],
  roles: [],
});

skiServiceDb.createUser({
  user: 'DMLUser',
  pwd: 'verySecurePassword',
  roles: ['DMLRole'],
});
