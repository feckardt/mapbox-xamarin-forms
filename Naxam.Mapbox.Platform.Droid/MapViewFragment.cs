using System;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Com.Mapbox.Mapboxsdk.Annotations;
using Com.Mapbox.Mapboxsdk.Maps;

namespace Naxam.Controls.Mapbox.Platform.Droid
{
    public class MapViewFragment : SupportMapFragment, MapView.IOnMapChangedListener
    {
        public delegate void MyHandler(int p1, string[] p2, Permission[] p3);
        public event EventHandler Started;
        public event EventHandler Stopped;
        public event EventHandler Destroyed;
        public event MyHandler RequestPermissionsResult;
        public MapView MapView { get; private set; }

        public MapView.IOnMapChangedListener OnMapChangedListener { get; set; }

        public bool StateSaved { get; private set; }

        public MapViewFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public MapViewFragment() : base()
        {

        }

        public override void OnStart()
        {
            base.OnStart();
            Started?.Invoke(this, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            MapView = view as MapView;
            MapView?.AddOnMapChangedListener(this);
        }

        public override void OnStop()
        {
            base.OnStop();
            Stopped?.Invoke(this,null);
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            MapView?.RemoveOnMapChangedListener(this);
            Destroyed?.Invoke(this,null);
        }
        public void OnMapChanged(int p0)
        {
            OnMapChangedListener?.OnMapChanged(p0);
        }

        public override void OnResume()
        {
            base.OnResume();
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
        }

        internal void ToggleInfoWindow(MapboxMap mapboxMap, Marker marker)
        {
            if (marker.IsInfoWindowShown)
            {
                mapboxMap.DeselectMarker(marker);
            }
            else
            {
                mapboxMap.SelectMarker(marker);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            RequestPermissionsResult?.Invoke(requestCode, permissions, grantResults);
        }


    }
}
