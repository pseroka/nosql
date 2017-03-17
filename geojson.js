const readline = require('readline')
const fs = require('fs')

const rl = readline.createInterface({
  input: fs.createReadStream('twitch_m.csv')
})

const countries = []
const json = {
  type: 'FeatureCollection',
  features: []
}
const colors = {
  PL: '#f00',
  DE: '#f00',
  FI: '#f00',
  NO: '#f00',
  SE: '#f00',
  DK: '#f00',
  UA: '#f00',
  AT: '#f00',
  IT: '#f00',
  CH: '#f00',
  BE: '#f00',
  IE: '#f00',
  GB: '#f00',
  FR: '#f00',
  ES: '#f00',
  PT: '#f00',
  NL: '#f00',
  
  US: '#00f',
  CA: '#00f',
  MX: '#00f',
  
  CO: '#0f0',
  BR: '#0f0',
  AR: '#0f0',
  PR: '#0f0',
  CL: '#0f0',
  
  JP: '#ff0',
  CN: '#ff0',
  KR: '#ff0',
  TW: '#ff0',
  VN: '#ff0',
  PK: '#ff0',
  IN: '#ff0',
  RU: '#ff0',
  SA: '#ff0',
  
  AU: '#f0f',
  NZ: '#f0f'
}

rl.on('line', line => {
  const l = line.split(',')
  const country = l[6]

  if (!countries.includes(country) && country !== 'None') {
    countries.push(country)

    const data = {
      type: 'Feature',
      properties: {
        'marker-color': colors[country] || '#0000ff',
        'marker-size': 'medium',
        'marker-symbol': '',
        channel_login: l[4],
        geo: country,
        viewers: l[5]
      },
      geometry: {
        type: 'Point',
        coordinates: [ l[l.length - 2], l[l.length - 1] ]
      }
    }

    json.features.push(data)
  }
}).on('close', () => {
  fs.writeFile('result.json', JSON.stringify(json), 'utf8', () => {})
})
