import { ISubject } from "./i-subject";
import { Teacher } from "./i-teacher";
import { IYear } from "./i-year";

export interface ILecture {
    id?:number;
    teacherId?:number;
    name?:string;
    details?:string;
    time?:number;
    cost?:number;
    published?:boolean
    publishedDate?:Date;
    limited?:boolean;
    limitedHours?:number;
    views?:number;
    specialViews?:number;
    yearid?:number;
    subjectId?:number;
    subject?:ISubject;
    teacher:Teacher;
    year:IYear;
}
