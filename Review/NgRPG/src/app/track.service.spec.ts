import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TrackService } from './track.service';
import { Track } from 'src/models/Track';
import { HttpErrorResponse } from '@angular/common/http';

describe('TrackService', () => {
  let service: TrackService;
  let httpMock: HttpTestingController;
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ]
    });
    httpMock = TestBed.inject(HttpTestingController);
    service = TestBed.inject(TrackService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should format time', () => {
    // Arrange
    const userProvidedTime = '4:33'
    const expectedOutput = '0.00:4:33.0000'

    // Act
    const actualOutput = service.formatTimeLength(userProvidedTime)

    // Assert (or Expect or Verify)
    expect(actualOutput).toEqual(expectedOutput)
  })

  it('should get all tracks', () => {
    // First, make request and expect some conditions
    service.getAllTracks().subscribe((res) => {
      // Verify that we received our test data
      expect(res).toBeTruthy()
      expect(res.length).toEqual(3)
    })

    // Is is making a right request? to the right place, witht the right verb?
    const req = httpMock.expectOne('http://localhost:5294/tracks')
    expect(req.request.method).toBe('GET')

    // if it is, resolve/respond to the request with our fake test data
    req.flush([
      {
        trackId: 1,
        artistName: 'Lakeside',
        trackName: 'Fantastic Voyage',
        genre: 'funk',
        trackLength: '6:10'
      },
      {
        trackId: 2,
        artistName: 'Ariana Grande',
        trackName: '34 + 35',
        genre: 'pop',
        trackLength: '2:35'
      },
      {
        trackId: 3,
        artistName: 'The Inkspots',
        trackName: 'I don\'t want to set the world on fire',
        genre: 'jazz',
        trackLength: '3:41'
      }
    ])
  })

  it('should create a new track', () => {
    // Arrange & Act
    const newTrack : Track = {
      trackId: 1,
      artistName: 'The Inkspots',
      trackName: 'I don\'t want to set the world on fire',
      genre: 'jazz',
      trackLength: '3:41'
    }
    service.createNewTrack(newTrack).subscribe(res => res)

    const req = httpMock.expectOne('http://localhost:5294/track')
    expect(req.request.method).toBe('POST')
    expect(req.request.body).toEqual(newTrack)

    // Create a fake server response with data/status/etc. 
    req.flush(null, {status: 200, statusText: 'OK'})
  })

  it('should not create a bad track', () => {
    // Arrange & Act
    const newTrack : Track = {
      artistName: '',
      trackName: 'I don\'t want to set the world on fire',
      genre: 'jazz',
      trackLength: '3:41'
    }
    service.createNewTrack(newTrack).subscribe({
      next: res => {
        fail()
      },
      error: (err : HttpErrorResponse) => {
        expect(err.status).toBe(400)
      }
    })

    const req = httpMock.expectOne('http://localhost:5294/track')
    expect(req.request.method).toBe('POST')
    expect(req.request.body).toBe(newTrack)

    req.flush(null, {status: 400, statusText: 'Bad Request'})
  })
});
