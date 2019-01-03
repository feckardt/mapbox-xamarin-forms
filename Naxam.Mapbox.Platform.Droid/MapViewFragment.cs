using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Com.Mapbox.Mapboxsdk.Annotations;
using Com.Mapbox.Mapboxsdk.Maps;

namespace Naxam.Controls.Mapbox.Platform.Droid
{
    public class MapViewFragment : SupportMapFragment, MapView.IOnMapChangedListener
    {
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

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            MapView = view as MapView;
            MapView?.AddOnMapChangedListener(this);
            MapView?.OnCreate(savedInstanceState);
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            MapView?.RemoveOnMapChangedListener(this);
            MapView?.OnDestroy();
        }

        public void OnMapChanged(int p0)
        {
            OnMapChangedListener?.OnMapChanged(p0);
        }

        public override void OnResume()
        {
            base.OnResume();
            MapView?.OnResume();
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            // This was causing crashes when minimizing app.
            base.OnSaveInstanceState(outState);
            MapView?.OnSaveInstanceState(outState);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            MapView?.OnCreate(savedInstanceState);
        }

        public override void OnStart()
        {
            base.OnStart();
            MapView?.OnStart();
        }

        public override void OnStop()
        {
            base.OnStop();
            MapView?.OnStop();
        }

        public override void OnPause()
        {
            base.OnPause();
            MapView?.OnPause();
        }

        public override void OnLowMemory()
        {
            base.OnLowMemory();
            MapView?.OnLowMemory();
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
    }
}
