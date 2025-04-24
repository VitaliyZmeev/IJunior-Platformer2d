using System;
using System.Collections;
using UnityEngine;

namespace Platformer2d
{
    public class Timer : MonoBehaviour
    {
        public const float TimeSmoothlyChangeDuration = 1f;

        private float _time;
        private float _duration;

        public float Duration => _duration;

        public event Action Started;
        public event Action Finished;
        public event Action Updated;
        public event Action<float> TimeChanged;

        public IEnumerator Run(float duration)
        {
            _duration = duration;
            SetTime(_duration);
            Started?.Invoke();

            while (_time > 0)
            {
                float targetTime = _time - TimeSmoothlyChangeDuration;

                yield return SmoothlyChangeTime(targetTime);

                Updated?.Invoke();
            }

            Finished?.Invoke();
        }

        private IEnumerator SmoothlyChangeTime(float targetTime)
        {
            float time = 0f;
            float startTime = _time;

            while (time < TimeSmoothlyChangeDuration)
            {
                time += UnityEngine.Time.deltaTime;

                float changeProgress = time / TimeSmoothlyChangeDuration;
                SetTime(Mathf.Lerp(startTime, targetTime, changeProgress));

                yield return null;
            }
        }

        private void SetTime(float time)
        {
            _time = time;
            TimeChanged?.Invoke(_time);
        }
    }
}