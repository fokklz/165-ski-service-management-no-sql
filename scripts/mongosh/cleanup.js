const skiServiceDb = db.getSiblingDB('SkiService');

if (skiServiceDb.getUser('DMLUser')) {
  skiServiceDb.dropUser('DMLUser');
}

if (skiServiceDb.getRole('DMLRole')) {
  skiServiceDb.dropRole('DMLRole');
}

if (skiServiceDb) {
  skiServiceDb.dropDatabase();
}
