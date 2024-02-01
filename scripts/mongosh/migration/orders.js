try{
db.getSiblingDB('SkiService').priorities.insertMany([
  {
    name: 'Alex',
    email: 'alex@example.com',
    phone: '1234567890',
    priority_id: ObjectId('65bac2721f0ce5a1a2b5f382'),
    service_id: ObjectId('65bac2711f0ce5a1a2b5f37f'),
    state_id: ObjectId('65bac2721f0ce5a1a2b5f380'),
    user_id: ObjectId('65baa8ce591ce541e27903aa'),
    created: new Date('2024-01-31T00:00:00.000Z'),
    note: null
  },
  {
    name: 'Jamie',
    email: 'jamie@example.com',
    phone: '0987654321',
    priority_id: ObjectId('65bac2721f0ce5a1a2b5f383'),
    service_id: ObjectId('65bac2711f0ce5a1a2b5f380'),
    state_id: ObjectId('65bac2721f0ce5a1a2b5f381'),
    user_id: ObjectId('65baa8ce591ce541e27903ab'),
    created: new Date('2024-02-01T00:00:00.000Z'),
    note: null
  },
  {
    name: 'Jordan',
    email: 'jordan@example.com',
    phone: '1122334455',
    priority_id: ObjectId('65bac2721f0ce5a1a2b5f384'),
    service_id: ObjectId('65bac2711f0ce5a1a2b5f381'),
    state_id: ObjectId('65bac2721f0ce5a1a2b5f382'),
    user_id: ObjectId('65baa8ce591ce541e27903ac'),
    created: new Date('2024-01-29T00:00:00.000Z'),
    note: null
  },
  {
    name: 'Sam',
    email: 'sam@example.com',
    phone: '5566778899',
    priority_id: ObjectId('65bac2721f0ce5a1a2b5f385'),
    service_id: ObjectId('65bac2711f0ce5a1a2b5f382'),
    state_id: ObjectId('65bac2721f0ce5a1a2b5f383'),
    user_id: ObjectId('65baa8ce591ce541e27903ad'),
    created: new Date('2024-02-02T00:00:00.000Z'),
    note: null
  },
  {
    name: 'Pat',
    email: 'pat@example.com',
    phone: '6677889900',
    priority_id: ObjectId('65bac2721f0ce5a1a2b5f386'),
    service_id: ObjectId('65bac2711f0ce5a1a2b5f383'),
    state_id: ObjectId('65bac2721f0ce5a1a2b5f384'),
    user_id: ObjectId('65baa8ce591ce541e27903ae'),
    created: new Date('2024-01-30T00:00:00.000Z'),
    note: 'Urgent follow-up required'
  },
  {
    name: 'Taylor',
    email: 'taylor@example.com',
    phone: '1112223333',
    priority_id: ObjectId('65bac2721f0ce5a1a2b5f387'),
    service_id: ObjectId('65bac2711f0ce5a1a2b5f384'),
    state_id: ObjectId('65bac2721f0ce5a1a2b5f385'),
    user_id: ObjectId('65baa8ce591ce541e27903af'),
    created: new Date('2024-02-03T00:00:00.000Z'),
    note: null
  },
  {
    name: 'Casey',
    email: 'casey@example.com',
    phone: '4445556666',
    priority_id: ObjectId('65bac2721f0ce5a1a2b5f388'),
    service_id: ObjectId('65bac2711f0ce5a1a2b5f385'),
    state_id: ObjectId('65bac2721f0ce5a1a2b5f386'),
    user_id: ObjectId('65baa8ce591ce541e27903b0'),
    created: new Date('2024-01-28T00:00:00.000Z'),
    note: 'Check for additional requirements'
  },
  {
    name: 'Morgan',
    email: 'morgan@example.com',
    phone: '7778889999',
    priority_id: ObjectId('65bac2721f0ce5a1a2b5f389'),
    service_id: ObjectId('65bac2711f0ce5a1a2b5f386'),
    state_id: ObjectId('65bac2721f0ce5a1a2b5f387'),
    user_id: ObjectId('65baa8ce591ce541e27903b1'),
    created: new Date('2024-02-04T00:00:00.000Z'),
    note: 'Pending approval from supervisor'
  },
  {
    name: 'Terry',
    email: 'terry@example.com',
    phone: '0001112222',
    priority_id: ObjectId('65bac2721f0ce5a1a2b5f38a'),
    service_id: ObjectId('65bac2711f0ce5a1a2b5f387'),
    state_id: ObjectId('65bac2721f0ce5a1a2b5f388'),
    user_id: ObjectId('65baa8ce591ce541e27903b2'),
    created: new Date('2024-01-27T00:00:00.000Z'),
    note: 'Special instructions attached'
  },
  {
    name: 'Cameron',
    email: 'cameron@example.com',
    phone: '3334445555',
    priority_id: ObjectId('65bac2721f0ce5a1a2b5f38b'),
    service_id: ObjectId('65bac2711f0ce5a1a2b5f388'),
    state_id: ObjectId('65bac2721f0ce5a1a2b5f389'),
    user_id: ObjectId('65baa8ce591ce541e27903b3'),
    created: new Date('2024-02-05T00:00:00.000Z'),
    note: null
  },
  {
    name: 'Reese',
    email: 'reese@example.com',
    phone: '6667778888',
    priority_id: ObjectId('65bac2721f0ce5a1a2b5f38c'),
    service_id: ObjectId('65bac2711f0ce5a1a2b5f389'),
    state_id: ObjectId('65bac2721f0ce5a1a2b5f38a'),
    user_id: ObjectId('65baa8ce591ce541e27903b4'),
    created: new Date('2024-01-26T00:00:00.000Z'),
    note: 'Customer requested expedited processing'
  },
  {
    name: 'Quinn',
    email: 'quinn@example.com',
    phone: '9990001111',
    priority_id: ObjectId('65bac2721f0ce5a1a2b5f38d'),
    service_id: ObjectId('65bac2711f0ce5a1a2b5f38a'),
    state_id: ObjectId('65bac2721f0ce5a1a2b5f38b'),
    user_id: ObjectId('65baa8ce591ce541e27903b5'),
    created: new Date('2024-02-06T00:00:00.000Z'),
    note: 'Requires additional documentation'
  },
  {
    name: 'Drew',
    email: 'drew@example.com',
    phone: '2223334444',
    priority_id: ObjectId('65bac2721f0ce5a1a2b5f38e'),
    service_id: ObjectId('65bac2711f0ce5a1a2b5f38b'),
    state_id: ObjectId('65bac2721f0ce5a1a2b5f38c'),
    user_id: ObjectId('65baa8ce591ce541e27903b6'),
    created: new Date('2024-01-25T00:00:00.000Z'),
    note: 'Follow up in two weeks'
  },
  {
    name: 'Skyler',
    email: 'skyler@example.com',
    phone: '5556667777',
    priority_id: ObjectId('65bac2721f0ce5a1a2b5f38f'),
    service_id: ObjectId('65bac2711f0ce5a1a2b5f38c'),
    state_id: ObjectId('65bac2721f0ce5a1a2b5f38d'),
    user_id: ObjectId('65baa8ce591ce541e27903b7'),
    created: new Date('2024-02-07T00:00:00.000Z'),
    note: 'Waiting on customer confirmation'
  },
]);
} catch (e) {
  console.error(e.writeErrors); // This line prints detailed error information
}