import React from 'react'
import { render } from 'react-dom'
import CardCohabitation from './CardCohabitation'

let user = {
  FIO: '',
  UniversityID: '',
  Age: 0,
  Course: 0,
  Phone: '',
  Email: '',
  DistrictId: '',
  Gender: '',
  UserDiscription: '',
  UserPassword: '',
  LinkToTelergamm: '',
  LinkToVk: '',
}

let data = {
  users: [
    { FIO: 'Denis', Age: 20, img: 'My.JPG' },
    { FIO: 'Grisha', Age: 20, img: 'Beer.JPG' },
    { FIO: 'Sergey', Age: 20, img: 'Serega.JPG' },
  ],
}

const Cards = () => {
  return (
    <div className="marg">
      <content>
        <div className='card_small'>
          <CardCohabitation us={data.users[0]} />
        </div>
        <div className='card_medium'>
          <CardCohabitation us={data.users[1]} />
        </div>
        <div className='card_medium'>
          <CardCohabitation us={data.users[2]} />
        </div>
        <div className='card_medium'>
          <CardCohabitation us={data.users[0]} />
        </div>
        <div className='card_medium'>
          <CardCohabitation us={data.users[1]} />
        </div>
        <div className='card_medium'>
          <CardCohabitation us={data.users[2]} />
        </div>
        <div className='card_medium'>
          <CardCohabitation us={data.users[1]} />
        </div>
      </content>
    </div>
  )
}

export { Cards };