db.getSiblingDB('SkiService').services.insertMany([
  {
    _id: ObjectId('65bac27374815d65e1a31bfa'),
    name: 'Kleiner Service',
    description:
      'Belag-Vorschliff und Belag-Strukturschliff für Ski, einschließlich Plan-Schliff, Diamant-Steinschliff und Wachsen & Polieren für optimale Gleitfähigkeit und Steuerung auf verschiedenen Schneebedingungen.',
    price: 49,
  },
  {
    _id: ObjectId('65bac27374815d65e1a31bfb'),
    name: 'Grosser Service',
    description:
      'Planschleifen für präzise ebene Ski-Kanten und Belag, maschinelles Kanten-Schleifen für scharfe Kanten, Belagaufbesserung, Belag-Vorschliff, Belag-Strukturschliff und Entgraten zur Optimierung von Gleitverhalten, Lenkung und Haltbarkeit der Ski.',
    price: 69,
  },
  {
    _id: ObjectId('65bac27374815d65e1a31bfc'),
    name: 'Rennski-Service',
    description:
      'Planschleifen, maschinellem Kanten-Schleifen und Belagaufbesserung für maximale Geschwindigkeit und Präzision. Fortschrittliches Weltcup-Wachs für höchste Gleiteigenschaften und Langlebigkeit. Entgraten und Handfinish für optimale Skioberfläche und Wettkampfqualität.',
    price: 99,
  },
  {
    _id: ObjectId('65bac27374815d65e1a31bfd'),
    name: 'Bindung montieren und einstellen',
    description:
      'Professionelle Montage und Einstellung von Ski-Bindungen durch Expertenteam für maximale Sicherheit und Performance. Präzise Montage und individuelle Einstellung für optimalen Halt, schnelles Ansprechen bei Stürzen und Anpassung an den Fahrstil.',
    price: 39,
  },
  {
    _id: ObjectId('65bac27374815d65e1a31bfe'),
    name: 'Fell zuschneiden pro Paar',
    description:
      'Maßgeschneiderte Skitouren-Felle, angepasst durch unser Fachteam für optimalen Grip und geschmeidiges Gleiten. Sorgfältiges Zuschneiden gewährleistet Effizienz und Komfort bei Skitouren.',
    price: 25,
  },
  {
    _id: ObjectId('65bac27374815d65e1a31bff'),
    name: 'Heisswachsen',
    description:
      'bietet tiefe Wachsimprägnierung für herausragendes Gleiterlebnis. Verfügbar als eigenständige Dienstleistung zur optimalen Vorbereitung der Skier für maximale Performance bei jedem Abfahrtslauf.',
    price: 18,
  },
]);
