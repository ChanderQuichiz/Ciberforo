import { User } from "./User";

export interface Topic {
    id:string;

    title:string;
    
    
    content:string;
    
    isDeleted:boolean;
    
    createdAt:Date;
    
    updatedAt:Date;
    
    userId:number;
    user?:User;
}