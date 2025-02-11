export interface LeaveRequest {
    id: number;
    employeeName: string;
    leaveType: 'Sick' | 'Vacation' | 'Other';
    startDate: string;
    endDate: string;
    status: 'Pending' | 'Approved' | 'Rejected';
  }

  export interface LeaveApprove{
    noOfLeaves: number;
    id:number;
    startDate:Date;
    endDate:Date;
    employeeName:string;
    status:string;
  }