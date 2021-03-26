import React, { useState, useEffect } from 'react';
import ReactDOM from 'react-dom';

import './index.css';
import axios from 'axios';

let inited = false;

const root = document.getElementById('root');

ReactDOM.render(<Options />, root);

function Options () {

  const [litems, setLItems] = useState([]);
  const [ritems, setRItems] = useState([]);

  useEffect(() => {

    if (inited) {
      return;
    }

    inited = true;
    init();
  });

  return (
    <div>
     <div className='container'>
        <div className='left'>
          <select multiple id='left'>
           {litems.map((item) => {
             return (<option key={item} value={item} onDoubleClick={() => {
               moveRight();
             }}>{item}</option>);
           })}
        </select>
      </div>

      <div className='middle'>
        <button type='button' onClick={() => { moveRight(); }}>{'>>>'}</button>
        <button type='button' onClick={() => { moveLeft(); }}>{'<<<'}</button>
        <button type='button' onClick={() => { GenerateEmail(); }}>{'Generate Email'}</button>
      </div>

      <div className='right'>
        <select multiple id='right'>
          {ritems.map((item) => {
            return (<option key={item} value={item} onDoubleClick={() => {
              moveLeft();
            }}>{item}</option>);
          })}
        </select>
      </div>
    </div>
    
    <div className='bottom'>
         <textarea id='email'></textarea>
      </div>
    </div>
    
  );

  function init () {
    var arr = ['boat-house-frontend','boat-house-backend','boat-house-infrastructure'];
    setLItems(arr.map((item) => {
           return item;
     }));
   // axios.get('http://localhost:8081/logs')
   //   .then(function (response) {
    //    setLItems(response.data.map((item) => {
    //      return item.Level;
    //    }));
    //  }).catch(function (error) {
    //    console.log(error);
   //   });

  }

  function moveRight () {
    let item = document.getElementById('left');
    if (!item.value) {
      alert('select a left item to move');
      return;
    }
    document.getElementById('email').value ="";
    //let items = litems.slice().filter((_item) => {
   let selectitems = [];
   for(var i=0;i<item.selectedOptions.length;i++){
        selectitems.push(item.selectedOptions[i].value);
    };

    let items = litems.slice().filter((_item) => {
      return selectitems.indexOf(_item) < 0;
    });
      //return item !== _item;

    setLItems(items);

    ritems.push.apply(ritems, selectitems);

    setRItems(ritems);
  }

  function moveLeft () {

    let item = document.getElementById('right');
    if (!item.value) {
      alert('select a right item to move');
      return; 
    }
    document.getElementById('email').value ="";
    let selectitems = [];
    for(var i=0;i<item.selectedOptions.length;i++){
        selectitems.push(item.selectedOptions[i].value);
    };

    let items = ritems.slice().filter((_item) => {
      return selectitems.indexOf(_item) < 0;
    });

    setRItems(items);
    litems.push.apply(litems, selectitems);

    setLItems(litems);
  }

  function GenerateEmail(){
    var context = '';
    
    if(ritems.length == 0){
        alert('Please choose a Repos!');
        return; 
    }

    for(var i=0;i<ritems.length;i++){
      context += ' - ' + ritems[i] + " 基础设施库，包括vm环境创建脚本，devops相关工具部署脚本\r\n";
    };
    document.getElementById('email').value = context;
  }
}