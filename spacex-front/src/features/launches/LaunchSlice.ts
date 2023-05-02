import {  createSlice } from '@reduxjs/toolkit'
import { RootState } from '../../app/store';

export interface LaunchState{
       
        api: 'remote' | 'local',
        status:'past' | 'upcoming'
}

const initialState: LaunchState = {
   api: 'remote',
   status: 'past',

}


export const launcherSlice = createSlice({
  name: 'launcher',
  initialState,
  reducers: {
      remoteApi: (state) =>
      {
         state.api='remote';
      },
      localApi:(state) =>
      {
        state.api='local';
      },
      pastData:(state)=>
      {
        state.status='past';
      },
      upcomingData:(state)=>
      {
        state.status='upcoming'
      }

      
  },
  
});

export const { remoteApi, localApi, pastData,upcomingData } = launcherSlice.actions;

export const selectLauncher = (state: RootState) => state.launcher;

export default launcherSlice.reducer