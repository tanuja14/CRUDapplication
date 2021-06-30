import { Component } from '@angular/core';
import { Observable, Subscribable } from 'rxjs';
import { TrackingDetails } from 'src/Models/TrackingDetails';
import { TrackingInfoService } from 'src/services/trackingInfo.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'Tracking Details';
  TrackingInfo:TrackingDetails=new TrackingDetails("","","","");
  TrackingList:TrackingDetails[]=[];
  server:TrackingInfoService
 

  constructor(serve:TrackingInfoService){
    this.server=serve;
    this.getTrackingDetails();
  }
getTrackingDetails(){
  this.server.getTrackingData().subscribe(e =>{
   this.TrackingList=e;
  });
}

SaveRecord(){
  this.server.SaveRecord(this.TrackingInfo).subscribe(e =>{
    alert(e);
    this.getTrackingDetails();
    this.TrackingInfo=new TrackingDetails("","","","");
   });
  }
  Edit(i:any){
    debugger
    this.TrackingInfo=i; 
 }
 DeleteRecord(i:any){
  debugger
  this.TrackingInfo=i;
    this.server.DeleteRecord(this.TrackingInfo).subscribe(e =>{
      alert(e);
      this.getTrackingDetails();
     });
 }
}

