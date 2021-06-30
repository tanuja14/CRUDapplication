export class TrackingDetails {
    SNo: string
    OrderId:string
    ShipmentDate:string
    DeliveryDate:string
    constructor(sno: string,orderId:string,shipmentDate:string,deliveryDate:string){
        this.SNo=sno;
        this.OrderId=orderId;
        this.ShipmentDate=shipmentDate;
        this.DeliveryDate=deliveryDate;
    }
}
