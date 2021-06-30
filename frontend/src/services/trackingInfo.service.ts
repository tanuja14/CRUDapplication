import { Injectable } from '@angular/core';
import {HttpClient}  from '@angular/common/http'
import { TrackingDetails } from 'src/Models/TrackingDetails';
@Injectable({
  providedIn: 'root'
})
export class TrackingInfoService {
http:HttpClient
URL="https://localhost:44397/api/TrackWebAPI/";
constructor(http:HttpClient) { 
  this.http=http;
}


getTrackingData(){
 return this.http.get<TrackingDetails[]>(this.URL+"GetTrackingDetails");

}

SaveRecord(obj:any){
 return this.http.post<TrackingDetails[]>(this.URL+"SaveTrackingDetails",obj);
}

DeleteRecord(obj:any){
  return this.http.post<TrackingDetails[]>(this.URL+"DeleteTrackingDetails",obj);
 }

}
