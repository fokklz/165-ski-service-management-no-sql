const adminDb = db.getSiblingDB('admin');
const skiServiceDb = db.getSiblingDB('SkiService');

if (!adminDb.getUser('superadmin')) {
  adminDb.createUser({
    user: 'superadmin',
    pwd: 'superadmin',
    roles: ['root'],
  });
}

skiServiceDb.createRole({
  role: 'DMLRole',
  privileges: [
    {
      resource: { db: 'SkiService', collection: '' },
      actions: ['find', 'insert', 'update', 'remove', 'listCollections'],
    },
  ],
  roles: [],
});

skiServiceDb.createUser({
  user: 'DMLUser',
  pwd: 'verySecurePassword',
  roles: ['DMLRole'],
});
