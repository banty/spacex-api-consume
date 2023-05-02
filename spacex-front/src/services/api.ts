import axios, { AxiosResponse } from "axios"
import { Launch } from "../features/launches/types";
import {  getUrl } from "./Env";



 const instance = axios.create({
    
    timeout: 15000,
});
 const responseBody = (response: AxiosResponse) => response.data;
 const launchRequests = {
     get: (url: string) => instance.get<Launch>(url).then(responseBody),
    
 };
 
 export const Launches ={
     getLaunches : (api:string,status:string) : Promise<Launch[]> => launchRequests.get(`${getUrl(api)}/${status}`),
     getSingleLaunch : (api:string,id : string|undefined) : Promise<Launch> => launchRequests.get(`${getUrl(api)}/${id}`),
     
 }