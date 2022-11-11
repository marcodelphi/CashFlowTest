import { BehaviorSubject, Observable, ReplaySubject, Subject } from "rxjs";

export abstract class ObservablesHelper {
    public static createSubjectStreams<T>(): [subject: Subject<T>, observable: Observable<T>] {
        const subject = new Subject<T>();
        return [subject, subject.asObservable()];
    }

    public static createReplayStreams<T>(): [subject: ReplaySubject<T>, observable: Observable<T>] {
        const subject = new ReplaySubject<T>(1);
        return [subject, subject.asObservable()];
    }

    public static createBehaviorStreams<T>(defaultValue: T): [subject: BehaviorSubject<T>, observable: Observable<T>] {
        const subject = new BehaviorSubject<T>(defaultValue);
        return [subject, subject.asObservable()];
    }
}