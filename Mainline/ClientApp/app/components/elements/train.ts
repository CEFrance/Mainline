export interface ITrainState {
    locomotives: ITrain[];
    state: ISpeedAndDirection[];
}

export interface ITrain {
    id: string;
    name: string;
    class: string;
    number: string;
    owner: string;
    role: Role;
    functions: IFunctions;
}

export enum Role {
    mixed = 0,
    passenger = 1,
    freight = 2
}

export interface IFunctions {
    eAddress: number;
    hasSound: boolean;
}

export interface ISpeedAndDirection {
    eAddress: number;
    speed: number;
    direction: number;
}