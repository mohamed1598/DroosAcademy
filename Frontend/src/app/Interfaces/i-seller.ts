import { ICenter } from "./i-center";

export interface ISeller {
    id?:number;
    fullname?:string;
    email?:string;
    password?:string;
    phoneNumber?:string;
    centerId?:number;
    status?:boolean;
    center?:ICenter
}
