import React, { useState, useEffect } from 'react';
import ReactDOM from 'react-dom';

import './index.css';
import axios from 'axios';

let inited = false;
var url = "https://localhost:44373/api";

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
   // var arr = ['boat-house-frontend','boat-house-backend','boat-house-infrastructure'];
  //  setLItems(arr.map((item) => {
  //         return item;
    // }));
    axios.get(url + '/MgFavorRepos/Load')
      .then(function (response) {
        if(response.data == ''){
           alert("访问github地址失败，该地址不稳定，请重试！");
           return;
        } 
        setLItems(response.data.map((item) => {
          return item.name;
        }));
      }).catch(function (error) {
        console.log(error);
     });
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
    
    //setLItems(items);

    ritems.push.apply(ritems, selectitems);
    Switch(items,ritems);


    //setRItems(ritems);
  }

  function Switch(left,right){
    axios.get(url + "/MgFavorRepos/Switch?left='" + left + "'&right='" +right + "'" )
    .then(function (response) {
      var le = JSON.parse(response.data.split(';')[0]);
      var ri = JSON.parse(response.data.split(';')[1]);
      var learr = [];
      var riarr =[];
      for(var i =0;i<le.length;i++){
            learr.push(le[i].name);
      }
      setLItems(learr);
      for(var i =0;i<ri.length;i++){
        riarr.push(ri[i].name);
      }
      setRItems(riarr);
    }).catch(function (error) {
      console.log(error);
   });
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

    //setRItems(items);
    litems.push.apply(litems, selectitems);
    Switch(litems,items);
    //setLItems(litems);
  }

  function GenerateEmail(){
    if(ritems.length == 0){
        alert('Please choose a my favor Repos!');
        return; 
    }

    axios.get(url + '/MgFavorRepos/GenerateEmail')
      .then(function (response) {
        if(response.data == ''){
           alert("访问github地址失败，该地址不稳定，请重试！");
           return;
        } 
        document.getElementById('email').value = response.data;
      }).catch(function (error) {
        console.log(error);
     });
  }
}