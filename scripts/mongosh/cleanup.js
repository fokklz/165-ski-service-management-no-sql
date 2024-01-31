const adminDb = db.getSiblingDB('admin');
const skiServiceDb = db.getSiblingDB('SkiService');

if (adminDb.getUser('superadmin')) {
  adminDb.dropUser('superadmin');
}

if (skiServiceDb.getUser('DMLUser')) {
  skiServiceDb.dropUser('DMLUser');
}

if (skiServiceDb.getRole('DMLRole')) {
  skiServiceDb.dropRole('DMLRole');
}

if (skiServiceDb) {
  skiServiceDb.dropDatabase();
}
