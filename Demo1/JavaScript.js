import React,{useState} from 'react';

import {
  DataGrid, Column, Editing, Scrolling, Lookup, Summary, TotalItem,
} from 'devextreme-react/data-grid';
import { Button } from 'devextreme-react/button';
import { SelectBox } from 'devextreme-react/select-box';

import CustomStore from 'devextreme/data/custom_store';
import { formatDate } from 'devextreme/localization';
import 'whatwg-fetch';

const URL = 'http://localhost:2341/api';




export default () =>{ 
    const [state, setstate] = useState(
         new CustomStore({
          key: 'providerId',
          load: () => sendRequest(`${URL}/provider`),
        //   insert: (values) => sendRequest(`${URL}/provider`, 'POST', {
        //     values: JSON.stringify(values),
        //   }),
       insert: (values) => sendRequest(`${URL}/provider`, 'POST', JSON.stringify(values)),
        //   update: (key, values) => sendRequest(`${URL}/provider`, 'PUT', {
        //     key,
        //     values: JSON.stringify(values),
        //   }),

        update: (key, values) =>{

            values["providerId"]=key
            sendRequest(`${URL}/provider`, 'PUT',  JSON.stringify(values))
        } ,
          
          remove: (key) => sendRequest(`${URL}/provider/${key}`, 'DELETE', {
            key
          }),
        })
  )

  function sendRequest(url, method = 'GET', data = {}) {
    
   
    if (method === 'GET') {
      return fetch(url, {
        method,
        credentials: 'include',
      }).then((result) => result.json().then((json) => {
        if (result.ok) {
           
            return json
        };
        throw json.Message;
      }));
    }
    
    const params = Object.keys(data).map((key) => `${encodeURIComponent(key)}=${encodeURIComponent(data[key])}`).join('&');
   console.log(data)
    return fetch(url, {
      method,
      body: data,
      headers:{
        'Accept': 'application/json',
        // 'Content-type': 'application/json'
'Content-Type': 'application/json; charset=utf-8'
    },
      credentials: 'include',
    }).then((result) => {
      if (result.ok) {
       
        return result.text().then((text) => text && JSON.parse(text));
      }
      return result.json().then((json) => {
        throw json.Message;
      });
    });
  }

    return (
  <React.Fragment>
     <DataGrid
          id="grid"
          showBorders={true}
          dataSource={state}
          repaintChangesOnly={true}
        >
          <Editing
            
            mode="cell"
            allowAdding={true}
            allowDeleting={true}
            allowUpdating={true}
          />

          <Scrolling
            mode="virtual"
          />

          <Column dataField="providerId" >
          
          </Column>

          <Column dataField="name" >
          </Column>

       

         
        </DataGrid>
        
        
  </React.Fragment>
)};
